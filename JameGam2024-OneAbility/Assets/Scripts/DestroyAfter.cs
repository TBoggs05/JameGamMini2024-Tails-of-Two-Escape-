using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Destroy Card");
            StartCoroutine(DestroyIt());
        }

    }

    IEnumerator DestroyIt()
    {
        yield return new WaitForSeconds(2f);
            Destroy(this);
    }
}
