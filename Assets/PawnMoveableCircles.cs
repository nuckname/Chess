using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMoveableCircles : MonoBehaviour
{
    //just copy and pasted from SpawningMoveableCircles. not ideal fix later.

    public Collider2D[] collider;
    public bool isBlockingValue;
    public bool hasPieceBlocking = false;
    private ObjectClicker objectClicker;

    private void Awake()
    {
        objectClicker = FindObjectOfType<ObjectClicker>();
    }

    public void isBlocking()
    {
        collider = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 1f);

        //put this in a method.
        if (objectClicker.colorOfPieceClicked == "black")
        {
            BlockingCalculator();
        }

        if (objectClicker.colorOfPieceClicked == "white")
        {
            BlockingCalculator();
        }
    }

    private void BlockingCalculator()
    {
        if (collider.Length == 1)
        {
            return;
        }
        //[0] = The Circle Collider, [1] = powerup, [2] = a piece
        //if the same colored piece and a powerup square are on the same tile it should attack
        if (collider.Length == 3)
        {
            Destroy(gameObject);
            hasPieceBlocking = true;
        }
        else
        {
            
        }
    }
}
