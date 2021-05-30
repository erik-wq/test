using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemyBehaviour : MonoBehaviour
{
    public AIPath aiPath;
    private void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    /*private bool canFollow;
    public enum State
    {
        Idle,
        Follow,
        Kill
    }
    private State state = State.Idle;
    public void SetState(State newState)
    {
        state = newState;
        switch (state)
        {
            case State.Idle:
                SetState(State.Idle);
                break;
            case State.Follow:
                SetState(State.Follow);
                break;
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SetState(State.Follow);
        }
        else
            SetState(State.Idle);
    }*/
}
