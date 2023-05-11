using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBlockingPiece : MonoBehaviour
{
    public float lineLength = 1.0f;
    public bool isBlocking = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Knight":
                isBlocking = true;
                break;
            case "Pawn":
                isBlocking = true;
                break;
            case "Bishop":
                isBlocking = true;
                break;
            default:
                // do nothing
                break;
        }
    }

}
