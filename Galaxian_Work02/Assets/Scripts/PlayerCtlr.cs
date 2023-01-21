using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerCtlr : MonoBehaviour {
    public GameObject explosion;
    public float moveSpeed = 20f;
    private Vector2 moveDirection;
    private Rigidbody2D rb;

    public GameObject Gun;
    public GameObject FirePosition;

    [SerializeField]
    bool push=false;
    GameObject text;

    private float cool_down_time = 0;
    public float gun_distance = 0.2f;
    public float speed = 10f;
    GameObject objpool;
    [SerializeField] ObjctPoolController ObjPoolCtrl;
    GameObject leftbutton;
    [SerializeField] EventTrigger trigger;
    void Start( ) {
        objpool=GameObject.Find( "objpool" );
        ObjPoolCtrl = objpool.GetComponent<ObjctPoolController>();
        rb = GetComponent<Rigidbody2D>( );
        GetComponent<Rigidbody2D>( );
        //moveDirection = new Vector3( 0.0f, 0.0f,0.0f);
    }
    void Update( ) {

        ProcessInputs();
    }
    private void FixedUpdate( ) {
        Move( );
    }
    void ProcessInputs( ) {
        Debug.Log(push);
    }
    private void Move( ) {
        //rb.velocity = new Vector3( moveDirection.x * moveSpeed, 0.0f );
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("GameOver");
    }
    private void OnCollisionEnter2D( Collision2D collision ) {
        if( collision.gameObject.tag == "Enemy"/*||collision.gameObject.tag=="EnemyGun"*/ ) {
            Instantiate(explosion,transform.position,Quaternion.identity);
            this.gameObject.SetActive( false );
            text = GameObject.Find("Text (Legacy)");
            Text clear_text=text.GetComponent<Text>();
            clear_text.text = "GameOver!";
            Invoke("ChangeScene", 3.0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag== "EnemyGun")
        {
            Instantiate(explosion,transform.position,Quaternion.identity);
            this.gameObject.SetActive( false );
            text = GameObject.Find("Text (Legacy)");
            Text clear_text = text.GetComponent<Text>();
            clear_text.text = "GameOver!";
            Invoke("ChangeScene", 3.0f);
        }
    }
}