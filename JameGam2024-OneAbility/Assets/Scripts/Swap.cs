using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    public GameObject player;

   


    


        private void OnTriggerEnter2D(Collider2D collider)
        {
        if (collider.gameObject == player)
        {
            player.GetComponent<GameController>().IsBean = !player.GetComponent<GameController>().IsBean;
            Debug.Log("Swapped!");

            // stop movement
            //animation
            // change sprite
            // change active script
            // end animation
            // return moving
        }
        }


    // Add functionality to stop moving, play animation then continue moving





}
