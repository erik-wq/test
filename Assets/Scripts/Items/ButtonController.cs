using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    public Transform Door;

    private Vector3 startDoorPos;
    private Vector3 startButtonPos;

    private void Start()
    {
        startDoorPos.y = Door.transform.position.y;
        startButtonPos.y = transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Door.transform.DOMoveY(startDoorPos.y - 4f, 2f, false);
        transform.DOLocalMoveY(startButtonPos.y - 0.1f, 0.25f, false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Door.transform.DOMoveY(startDoorPos.y, 2f, false);
        transform.DOLocalMoveY(startButtonPos.y, 0.25f, false);
    }
}

// 2f + 0.047998f