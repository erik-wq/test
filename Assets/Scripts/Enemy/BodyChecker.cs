using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyChecker : MonoBehaviour
{
    public GameObject Player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Destroy(Player);
    }
}
