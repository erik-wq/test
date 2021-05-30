using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public float speed = 1f;
    bool movingRight = true;
   
    public Transform eye;

    
    public float eyeLaserLenght = 0.5f;

 

    public SpriteRenderer sr;

    public LayerMask eyeLM;



    void Start()
    {
        int nahodneCislo = Random.Range(0, 2);
        if (nahodneCislo == 0)
        {
            movingRight = true;
        }
        if (nahodneCislo == 1)
        {
            movingRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            sr.flipX = false;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            sr.flipX = true;

        }

        

        RaycastHit2D eyeTarget = Physics2D.Raycast(eye.position, Vector2.right, eyeLaserLenght, eyeLM);
        if (eyeTarget.collider != null)
        {
            Debug.DrawRay(eye.position, Vector2.right * eyeLaserLenght, Color.green);
            TurnBack();

        }
        else
        {
            Debug.DrawRay(eye.position, Vector2.right * eyeLaserLenght, Color.red);
        }
    }

    public void TurnBack()
    {
        movingRight = false;
    }
}