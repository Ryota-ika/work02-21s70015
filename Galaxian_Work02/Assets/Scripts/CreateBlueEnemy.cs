using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlueEnemy : MonoBehaviour {
    int ENEMY_WIDTH = 10;
    int ENEMY_HEIGHT = 3;
    public List<GameObject> blue_enemies = new List<GameObject>( );
    public GameObject blue_enemy;
    private float cool_down_time = 0;

    // Start is called before the first frame update
    void Start( ) {
        for( int i = 0; i < ENEMY_WIDTH; i++ ) {
            for( int j = 0; j < ENEMY_HEIGHT; j++ ) {
                GameObject g = Instantiate( blue_enemy, new Vector3( i * 0.6f - 2.7f, j * 0.6f + 2.6f, 0 ), Quaternion.identity );
                blue_enemies.Add( g );
                //blue_enemies.Count–¼‘O”Ô†
                g.name = "enemy" + blue_enemies.Count;

            }
        }
    }

    // Update is called once per frame
    void Update( ) {
        cool_down_time -= Time.deltaTime;

        if( cool_down_time <= 0 ) {
            blue_enemies.RemoveAll(item => item == null); 
            int create_random = Random.Range( 0, blue_enemies.Count );
            //blue_enemies.Add();
            //buleenemy1
            blue_enemies[ create_random ].GetComponent<AllEnemyCtlr>( ).move_enemy = true;

            cool_down_time = 3f;
        }
    }
    
}
