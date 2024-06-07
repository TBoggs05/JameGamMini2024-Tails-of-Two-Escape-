using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private bool InAir = false;
    private Rigidbody2D rb2d;

    void Start()
    {
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
        if (Input.GetKey(KeyCode.W) && !InAir)
        {
            gameObject.transform.Translate(Vector3.up * Time.deltaTime * jumpHeight);
        }


    }


}
