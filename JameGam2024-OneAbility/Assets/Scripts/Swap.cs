using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    public GameObject player;

    public bool IsBean;


    


        private void OnTriggerEnter2D(Collider2D collider)
        {
        if (collider.gameObject == player)
        {
            IsBean = !IsBean;
            Debug.Log("Swapped!");
        }
        }


    // Add functionality to stop moving, play animation then continue moving





}
