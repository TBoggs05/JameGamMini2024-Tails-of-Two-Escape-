using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Vector2 jumpHeight;
    [SerializeField] private bool InAir = false;
    private Rigidbody2D rb2d;

    void Start()
    {
        jumpHeight = new Vector2(0, 3);
        speed = 5f;
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ADD CHECK HERE FOR IF COLLIDING WITH SOMETHING WITH "GROUND" TAG TO AVOID WALL JUMPING!!!
        InAir = false;
        Debug.Log("InAir false");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        InAir = true;
        Debug.Log("InAir True");
    }
    void Update()
    {
        //Move left
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //Move Right
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        //JumpCode
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(jumpCoroutine());
            
        }


    }
    IEnumerator jumpCoroutine()
    {
        //do nothing until we are confirmed on ground.
        while (InAir) { yield return null; }
        jumpHeight = new Vector2(0, 3);
        float jumpTime = Time.time;
        while(!(Input.GetKeyUp(KeyCode.W) && !InAir))
        {
            //crouch down to jump animation?
            yield return null;
        }
        jumpTime = Time.time - jumpTime;
        Debug.Log(jumpTime);
             //on release, jump based on time.
             //max case
            if(jumpTime >= 1f)
            {
            jumpHeight.y *= 3f;
            }
            //min case
            else if(jumpTime < 0.5f)
            {
            jumpHeight.y *= 1f;
            }
            //standard case
            else
            {
            jumpHeight.y *= jumpTime * 2;
            }

            //jump force code
            rb2d.AddForce(jumpHeight, ForceMode2D.Impulse);
    }

}
