using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerFall : MonoBehaviour
{
    public Animator knockOverAnimation;
    private Rigidbody2D mommaRbody;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //if momma collided
        if (collider.gameObject.name == "MommaPlayer" || collider.gameObject.name == "MommaPlayer(Clone)")
        {
            mommaRbody = collider.gameObject.GetComponent<Rigidbody2D>();
            //if force on rigidbody is high enough(bash)
            if (Mathf.Abs(mommaRbody.velocity.x) > 0f)
            {
                //Trigger the animation
                Debug.Log("KNOCK OVER");
                knockOverAnimation.SetTrigger("Bambo");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<BoxCollider2D>().enabled = false;

            }

        }
    }



}
