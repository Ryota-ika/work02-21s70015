using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    [SerializeField] bool left_push = false;
    [SerializeField] bool right_push = false;
    [SerializeField] bool hit_push = false;
    public float speed = 10f;
    public GameObject player;
    private float cool_down_time = 0;
    GameObject objpool;
    [SerializeField] ObjctPoolController ObjPoolCtrl;
    GameObject FirePosition;
    public float gun_distance = 0.2f;
    // Start is called before the first frame update
    GameObject p;
    void Start()
    {
        p = Instantiate(player);
        p.name="player";
        objpool = GameObject.Find("objpool");
        ObjPoolCtrl = objpool.GetComponent<ObjctPoolController>();
        FirePosition = GameObject.Find("fire_position");
    }
    public void LeftPushDown()
    {
        left_push = true;
    }
    public void LeftPushUp()
    {
        left_push = false;
    }
    public void RightPushDown()
    {
        right_push = true;
    }
    public void RightPushUp()
    {
        right_push = false;
    }
    public void OnClick ()
    {
        hit_push = true;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(push);
        if ((right_push) && p.transform.position.x < 4.0f)
        {
            p.transform.position += p.transform.right * speed * Time.deltaTime;
        }
        if ((left_push ) && p.transform.position.x > -4.0f)
        {
            p.transform.position -= p.transform.right * speed * Time.deltaTime;
        }
        if (hit_push)
        {
            Fire();
            hit_push=false;
        }
        //Time.deltaTime==60ïbä‘Ç≈1ÉtÉåÅ[ÉÄï‘ÇµÇƒÇ≠ÇÍÇÈ
        cool_down_time -= Time.deltaTime;
    }
    private void Fire()
    {
        if (cool_down_time <= 0)
        {
            //instantiateÇÃë„ÇÌÇËÇÃä÷êî
            GameObject obj = ObjPoolCtrl.GetPooledObjct();
            if (obj == null)
            {
                return;
            }
            //èeÇÃèäíËà íuéÊìæ
            obj.transform.position = FirePosition.transform.position;
            obj.transform.rotation = FirePosition.transform.rotation;
            obj.SetActive(true);
            //Instantiate(Gun,FirePosition.transform.position,FirePosition.transform.rotation);
            cool_down_time = gun_distance;
        }
    }
}
