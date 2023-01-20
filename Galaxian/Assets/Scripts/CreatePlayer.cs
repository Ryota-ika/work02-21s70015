using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject p= Instantiate(player);
        p.name="player";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
