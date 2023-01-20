using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyCtlr : AllEnemyCtlr {
    Vector3 player_pos;
    Vector3 enemy_pos;
    bool flame1 = true;
    // Start is called before the first frame update
    //void Start( ) {

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    protected override void Attack( ) {
        if( flame1 ) {
            target = GameObject.Find( "player" );
            if( target == null ) {
                //target = null;
                player_pos = new Vector3( 0, 0, 0 );
            } else {
                player_pos = target.transform.position;
                enemy_pos = this.transform.position;
                flame1 = false;

            }
        }
        this.gameObject.transform.position += ( player_pos - enemy_pos ).normalized * Time.deltaTime * 2.0f;
        //Debug.Log( target.transform.position.normalized );
    }
}
