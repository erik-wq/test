using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatf : MonoBehaviour
{
    [Header("Choice moving direction")]
    public bool left;
    public bool right;
    [Tooltip ("How far platform will move")]public float movingDistance;
    [Tooltip ("how fast will platform move")]public float speed;
    Vector3 startPos;
    Vector3 finalPos;
    bool returnToStart = false;
    bool canMove=true;
    private void Start()
    {
        if(left && right)
        {
            canMove = false;
        }
        startPos = transform.position;
        if (left == true)
        {
            finalPos = startPos - new Vector3(movingDistance, 0, 0);
        }
        else
        {
            finalPos = startPos + new Vector3(movingDistance, 0, 0);
        }
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            if (left == true)
            {
                if (returnToStart == false)
                {
                    if (transform.position.x <= finalPos.x)
                    {
                        returnToStart = true;
                    }
                    else
                    {
                        transform.position += new Vector3(-speed * Time.fixedDeltaTime, 0, 0);
                    }
                }
                else
                {
                    if (transform.position.x >= startPos.x)
                    {
                        returnToStart = false;
                    }
                    else
                    {
                        transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
                    }
                }
            }
            else
            {
                if (returnToStart == false)
                {
                    if (transform.position.x >= finalPos.x)
                    {
                        returnToStart = true;
                    }
                    else
                    {
                        transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
                    }
                }
                else
                {
                    if (transform.position.x <= startPos.x)
                    {
                        returnToStart = false;
                    }
                    else
                    {
                        transform.position += new Vector3(-speed * Time.fixedDeltaTime, 0, 0);
                    }
                }
            }
        }
        else
        {
            Debug.Log("left or right choice one");
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
