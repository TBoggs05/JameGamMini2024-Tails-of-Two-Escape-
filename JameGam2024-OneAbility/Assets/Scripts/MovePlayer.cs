using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] public float speed;
    [SerializeField] private float jumpTime;
    private Rigidbody2D rbody;
    private SpriteRenderer spriteRenderer;

    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public bool movingRight;
    private float horizontal;

    //Initialize Variables before first frame.
    void Start()
    {
        speed = 5f;
        rbody = GetComponent<Rigidbody2D>();
        maxJumpPressure = 7f;
        minJump = 2f;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
     //Fixed Update to handle jumping + movement
     void FixedUpdate()
    {
         checkMove();
        //jumping code
            if (checkGround())
            {
                //holding jump butotn
                if (Input.GetKey(KeyCode.W))
                {
                    if (jumpPressure < maxJumpPressure)
                    {
                        jumpPressure += Time.deltaTime * 10f;
                    }
                
                    else
                    {
                        jumpPressure = maxJumpPressure;
                    }
                }
                //not holding jump button
                else
                {
                    //jump since no longer holding button and jump pressure exists
                    if(jumpPressure > 0f)
                    {
                        Debug.Log(jumpPressure);
                       
                        jumpPressure = jumpPressure + minJump;
                        rbody.velocity = new Vector3(0f,jumpPressure,0f);
                        jumpPressure = 0f;
                    
                    }
                }

            }  


    }
    //checks ground for jumping
   public bool checkGround()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
            return true;
        else
            return false;
    }
    //draws jumping hitbox
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
    //moving code
    public void checkMove()
    {
        //Move left
        if (Input.GetKey(KeyCode.A))
        {
            // Vector3 m_Input = Vector3.left;
              gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
            //rbody.MovePosition(transform.position + m_Input * Time.deltaTime * speed);
            spriteRenderer.flipX = true;
            movingRight = false;
        }
        //Move Right
        if (Input.GetKey(KeyCode.D)) 
        {
            // Vector3 m_Input = Vector3.right;
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed);
            // rbody.MovePosition(-transform.position + m_Input * Time.deltaTime * -speed);
            spriteRenderer.flipX = false;
            movingRight = true;
        }
    }
}
