using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Momma : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
