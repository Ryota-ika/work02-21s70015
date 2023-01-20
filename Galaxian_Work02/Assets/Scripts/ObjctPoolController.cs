using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjctPoolController : MonoBehaviour
{
    public GameObject pool_obj;
    public List<GameObject> pool_list=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject obj = Instantiate(pool_obj,this.transform);
            obj.SetActive(false);
            pool_list.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //GameObject型のデータを返すことができる
    public GameObject GetPooledObjct()
    {
        for (int i = 0; i < pool_list.Count; i++)
        {
            //対象のゲームオブジェクトがアクティブならtrue、非アクティブならfalseを返す
            if (pool_list[i].activeInHierarchy==false)
            {
                return pool_list[i];
            }
        }
        //何もないデータを返す
        return null;
    }
}
