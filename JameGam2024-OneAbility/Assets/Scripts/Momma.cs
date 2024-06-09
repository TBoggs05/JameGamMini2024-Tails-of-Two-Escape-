using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Momma : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 bashForce;
    [SerializeField] private bool bashReady;
    [SerializeField] private bool bashPress;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2.0f;
        bashReady = true;
        gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bashPress = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (bashPress)
        {
            bashPress = false;
            Debug.Log("Bash Attempt");
            if (GetComponent<MovePlayer>().checkGround())
            {
                if (bashReady)
                {
                    bashReady = false;
                    StartCoroutine(bashTimer());
                    rb.drag = 10f;
                    rb.gravityScale += 4f;
                    float tempSpeed = GetComponent<MovePlayer>().speed;
                    GetComponent<MovePlayer>().speed = 0;
                    Debug.Log("MOMMA-BASH!");
                    if (GetComponent<MovePlayer>().movingRight)
                    {
                        bashForce = new Vector2(32f, 0);
                    }
                    else
                    {
                        bashForce = new Vector2(-32f, 0);
                    }
                    rb.AddForce(bashForce, ForceMode2D.Impulse);
                    GetComponent<MovePlayer>().speed = tempSpeed;

                }
                else
                {
                    Debug.Log("No Bash!");
                }
            }
        }
    }
    IEnumerator bashTimer()
    {
        int timer = 3;
        while(timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if(timer == 2)
            {
                rb.gravityScale -= 4f;
                rb.drag = 0f;
            }
        }
        bashReady = true;

    }
}
