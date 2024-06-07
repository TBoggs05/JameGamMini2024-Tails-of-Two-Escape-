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
            Debug.Log("Swapped!");
            StartCoroutine(swapSequence());
        }
        }
    IEnumerator swapSequence()
    {

        float originalSpeed = player.GetComponent<MovePlayer>().speed;// store OG movement speed
        player.GetComponent<MovePlayer>().speed = 0; // stop movement
        //Start animation(maybe yield waitforseconds to ensure animation starts) TODO

        player.GetComponent<GameController>().swapCat();// change sprite + change active script.
        /*
         * while(animation != finished){
         * yield return null
         * }
         */
        // end animation

        player.GetComponent<MovePlayer>().speed = originalSpeed;// return moving
        yield return null; //TEMP TO STOP ERROR!
    }
}
