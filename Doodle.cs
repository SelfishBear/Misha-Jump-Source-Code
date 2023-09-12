using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doodle : MonoBehaviour
{
    public static Doodle instance;
    float horizontal;
    public Rigidbody2D DoodleRigid;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x;
        }
        if(Input.acceleration.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if(Input.acceleration.x > 0 )
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        DoodleRigid.velocity = new Vector2(Input.acceleration.x * 14f, DoodleRigid.velocity.y);
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "DeadZone") {
            SceneManager.LoadScene(0);
        }
    }
}
