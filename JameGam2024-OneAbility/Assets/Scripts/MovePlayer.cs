using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

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
    public float horizontalCastOffset;
    public LayerMask groundLayer;
    public bool movingRight;
    private float horizontal;
   [SerializeField] private AudioManager audioManager;
    public GameObject mainCamera;
    public Animator animator;
    //Initialize Variables before first frame.
    void Start()
    {
        if(mainCamera == null)
        mainCamera = GameObject.Find("Main Camera");
        audioManager = FindObjectOfType<AudioManager>();
        speed = 5f;
        rbody = GetComponent<Rigidbody2D>();
        maxJumpPressure = 7f;
        minJump = 2f;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Fixed Update to handle jumping + movement
    private void Update()
    {
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))  && checkGround())
            {
            //animate
            animator.SetBool("Moving", true);
            }
        else
        {
            //animate
            animator.SetBool("Moving", false);
        }
        }
    void FixedUpdate()
    { 
         checkMove();
        //jumping code
            if (checkGround())
            {
                //holding jump butotn
                if (Input.GetKey(KeyCode.W) || Input.GetKey("space"))
                {
                animator.SetBool("Jumpstart", true);
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
                    animator.SetBool("Jumpstart", false);
                    animator.SetBool("Jumping", true);
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
        {
            animator.SetBool("isGrounded", true);
            animator.SetBool("Jumping", false);
            return true;
        }
            
        else
        {
            animator.SetBool("isGrounded", false);
            return false;
        }
       

    }
    //draws jumping hitbox
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube((transform.position - transform.up * castDistance), boxSize);
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
            // spriteRenderer.flipX = true;
            flipCharacter();
            movingRight = false;
           
        }
        //Move Right
        if (Input.GetKey(KeyCode.D)) 
        {
            // Vector3 m_Input = Vector3.right;
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed);
            // rbody.MovePosition(-transform.position + m_Input * Time.deltaTime * -speed);
            //spriteRenderer.flipX = false;
            flipCharacter();
            movingRight = true;
        }

    }
    public void flipCharacter()
    {
        if (movingRight)
        {
                transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else
        {
                transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }
    }
}
