using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class OperatePlayer : MonoBehaviour
{
    bool push=false;
    public float speed = 10f;
    [SerializeField] PlayerCtlr playerCtr;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerCtlr>();
    }

    public void PushDown()
    {
        push = true;
    }
    public void PushUp()
    {
        push = false;
    }
    // Update is called once per frame
    void Update()
    {
        //if ( push && transform.position.x < 4.0f)
        //{
        //    transform.position += transform.right * speed * Time.deltaTime;
        //}
        if ((push||Input.GetKeyDown(KeyCode.A) )&& player.transform.position.x > -4.0f)
        {
            player.transform.position -= player.transform.right * speed * Time.deltaTime;
        }
    }
}
