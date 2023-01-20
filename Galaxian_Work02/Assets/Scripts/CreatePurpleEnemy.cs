using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePurpleEnemy : MonoBehaviour
{
    int ENEMY_WIDTH=8;
    public List<GameObject> purple_enemies = new List<GameObject>();
    public GameObject purple_enemy;
    private float cool_down_time=1;
    // Start is called before the first frame update
    void Start()
    {
        for( int i = 0; i < ENEMY_WIDTH; i++ ) {
            GameObject g = Instantiate( purple_enemy, new Vector3( i * 0.6f - 2.1f, 4.4f, 0 ), Quaternion.identity );
            purple_enemies.Add(g);
            g.name = "enemy"+purple_enemies.Count;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        cool_down_time -= Time.deltaTime;

        if( cool_down_time <= 0 ) {
            purple_enemies.RemoveAll(item => item == null);
            int create_random = Random.Range( 0, purple_enemies.Count );
            //buleenemy1
            purple_enemies[ create_random ].GetComponent<AllEnemyCtlr>( ).move_enemy = true;
            cool_down_time = 5f;
        }
    }
}
