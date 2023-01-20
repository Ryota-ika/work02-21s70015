using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRedEnemy : MonoBehaviour {
    const int ENEMY_WIDTH = 6;
    public List<GameObject> red_enemies = new List<GameObject>();
    public GameObject red_enemy;
    private float cool_down_time = 2;
    // Start is called before the first frame update
    void Start( ) {
        for( int i = 0; i < ENEMY_WIDTH; i++ ) {
            GameObject g = Instantiate( red_enemy, new Vector3( i * 0.6f - 1.5f, 5, 0 ), Quaternion.identity);
            red_enemies.Add( g );
            g.name="enemy"+red_enemies.Count;



        }
    }

    // Update is called once per frame
    void Update( ) {
        cool_down_time -= Time.deltaTime;

        if( cool_down_time <= 0 ) {
            red_enemies.RemoveAll (item => item == null);
            int create_random = Random.Range( 0, red_enemies.Count );
            //buleenemy1
            red_enemies[ create_random ].GetComponent<AllEnemyCtlr>( ).move_enemy = true;
            cool_down_time = 10f;
        }
    }
}
