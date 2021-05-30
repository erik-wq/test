using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Destroy(transform.parent.gameObject);

    }
}
