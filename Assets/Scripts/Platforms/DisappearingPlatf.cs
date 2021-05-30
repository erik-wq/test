using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatf : MonoBehaviour
{
    bool playerOnTop = false;
    [Header ("Timers for platform")]
    [Tooltip ("How long can player stand on platform in seconds")]public float life;
    float lifeTime;
    [Tooltip("Time to respawn platform in seconds")]public float respawnTime;
    float timeToRespawn;
    [Header ("Do not change")]
    public GameObject body;
    public GameObject triger;
    bool turnOff=false;
    void Start()
    {
        lifeTime = life;
    }

    void Update()
    {
        if (playerOnTop || lifeTime < life)
        {
            lifeTime -= Time.deltaTime;
        }
        if (lifeTime <= 0 && turnOff == false)
        {
            triger.SetActive(false);
            body.SetActive(false);
            turnOff = true;
            lifeTime = life;
        }
        if(turnOff == true && timeToRespawn<respawnTime)
        {
            timeToRespawn += Time.deltaTime;
        }
        else
        {
            triger.SetActive(true);
            body.SetActive(true);
            turnOff = false;
            timeToRespawn = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerOnTop = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerOnTop = false;
        }
    }
}
