using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bean : MonoBehaviour
{
    [SerializeField] private float jumpTime;
    private Rigidbody2D rbody;
    private SpriteRenderer spriteRenderer;

    private float wallJumpPressure;
    private float minWallJump;
    private float maxWallJumpPressure;
    public Vector2 wallBoxSize;
    public float castDistance;
    public LayerMask wallLayer;

    [SerializeField] public bool isWallSliding;
    [SerializeField] private float wallSlidingSpeed = 2f;
    [SerializeField] private Transform wallCheck;

    [SerializeField] private bool isWallJumping;
    [SerializeField] private float wallJumpingDirection;
    [SerializeField] private float wallJumpingTime = 0.2f;
    [SerializeField] private float wallJumpingCounter;
    [SerializeField] private float wallJumpingDuration;
    [SerializeField] private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 1.0f;
        maxWallJumpPressure = 10f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        wallJumpingCounter = 0;
    }
    void Update(){
        WallSlide();
        //jumping code
        if (checkWall() && !IsGrounded())
        {
            //slide down wall slowly.
            WallSlide();
            if (isWallSliding)
            {
                //holding jump butotn
                if (Input.GetKey(KeyCode.W) || Input.GetKey("space"))
                {
                    Debug.Log("Queueing up wall jump!");
                    if (wallJumpPressure < maxWallJumpPressure)
                    {
                        wallJumpPressure += Time.deltaTime * 30f;
                    }

                    else
                    {
                        wallJumpPressure = maxWallJumpPressure;
                    }
                }
                //not holding jump button
                else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp("space"))
                {
                    //jump since no longer holding button and jump pressure exists
                    if (wallJumpPressure > 0f)
                    {
                        
                        if (GetComponent<MovePlayer>().movingRight)
                        {
                            rbody.AddForce(-transform.right * wallJumpPressure, ForceMode2D.Impulse);
                        }
                        else
                        {
                            rbody.AddForce(transform.right * wallJumpPressure, ForceMode2D.Impulse);
                        }
                        Debug.Log("Wall jump pressure: " + wallJumpPressure);
                        if (wallJumpPressure < 4f)
                        {
                            wallJumpPressure = 4f;
                        }
                        wallJumpPressure = wallJumpPressure + minWallJump;
                        rbody.velocity = new Vector3(0f, wallJumpPressure, 0f);
                        wallJumpPressure = 0f;

                    }

                }
            }
        }


    }
   
    //checks ground for jumping
    bool checkWall()
    {
        if (Physics2D.BoxCast(transform.position, wallBoxSize, 0, -transform.up, castDistance, wallLayer))
            return true;
        else
            return false;
    }
    //draws jumping hitbox
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, wallBoxSize);
    }
    private bool IsGrounded()
    {
        return GetComponent<MovePlayer>().checkGround();
    }
    private void WallSlide()
    {
        if(checkWall() && !IsGrounded()){
           // Debug.Log("Wall Sliding!");
            isWallSliding = true;
            rbody.velocity = new Vector2(rbody.velocity.x, Mathf.Clamp(rbody.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }
    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
        }
    }
}


