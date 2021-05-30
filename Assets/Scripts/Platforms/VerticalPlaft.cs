using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlaft : MonoBehaviour
{
    [Header("Choice moving direction")]
    public bool up;
    public bool down;
    [Tooltip("How far platform will move")] public float movingDistance;
    [Tooltip("how fast will platform move")] public float speed;
    bool canMove = true;
    bool returnToStart=false;
    Vector3 startPos;
    Vector3 finalPos;
    // Start is called before the first frame update
    void Start()
    {
        if (up && down)
        {
            canMove = false;
        }
        startPos = transform.position;
        if (up == true)
        {
            finalPos = startPos + new Vector3(0, movingDistance, 0);
        }
        else
        {
            finalPos = startPos - new Vector3(0, movingDistance, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            if (up == true)
            {
                if (returnToStart == false)
                {
                    if (transform.position.y >= finalPos.y)
                    {
                        returnToStart = true;
                    }
                    else
                    {
                        transform.position += new Vector3(0, speed*Time.fixedDeltaTime, 0);
                    }
                }
                else
                {
                    if (transform.position.y <= startPos.y)
                    {
                        returnToStart = false;
                    }
                    else
                    {
                        transform.position += new Vector3(0, -speed*Time.fixedDeltaTime, 0);
                    }
                }
            }
            else
            {
                if (returnToStart == false)
                {
                    if (transform.position.y <= finalPos.y)
                    {
                        returnToStart = true;
                    }
                    else
                    {
                        transform.position += new Vector3(0, -speed*Time.fixedDeltaTime, 0);
                    }
                }
                else
                {
                    if (transform.position.y >= startPos.y)
                    {
                        returnToStart = false;
                    }
                    else
                    {
                        transform.position += new Vector3(0, speed*Time.fixedDeltaTime, 0);
                    }
                }
            }
        }
        else
        {
            Debug.Log("up or down choice one");
            this.gameObject.SetActive(false);
        }
    }
}
