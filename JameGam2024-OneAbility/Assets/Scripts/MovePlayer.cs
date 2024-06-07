using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpTime;
    private Rigidbody2D rbody;

    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    void Start()
    {
        speed = 5f;
        rbody = GetComponent<Rigidbody2D>();
        maxJumpPressure = 10f;
    }
    void Update()
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
                    if(jumpPressure < 2.5f)
                    {
                        jumpPressure = 2.5f;
                    }
                    jumpPressure = jumpPressure + minJump;
                    rbody.velocity = new Vector3(0f,jumpPressure,0f);
                    jumpPressure = 0f;
                    
                }
            }

        }


    }
    //checks ground for jumping
    bool checkGround()
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
    void checkMove()
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
    }
  
   
  
}
