using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectController : MonoBehaviour
{
    private Vector3 startPos;
    private Rigidbody2D rb;
    //private float startGravity;

    private void Start()
    {
        startPos = gameObject.transform.position;
        rb = GetComponent<Rigidbody2D>();
        //startGravity = rb.gravityScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rb.gravityScale = 0;
            gameObject.transform.position = startPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.gravityScale = 1;
        }
    }
}
