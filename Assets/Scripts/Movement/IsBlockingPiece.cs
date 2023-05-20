using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBlockingPiece : MonoBehaviour
{
    //need to use GetColorPosOnClick
    public Collider2D[] collider;

    public bool isBlockingValue;
    public bool test = false;

    public Color color;

    public void Start()
    {
        //isBlocking = false;
        collider = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 1f);
        //isBlockingValue = isBlocked();
    }

   // public void isBlocked()
    public bool isBlocked(GameObject instantatedCircle)
    {
        //collider variable could be giving errors.
        if (collider.Length >= 2)
        {
            //Destroy(this.gameObject);
            //isBlocking = true;
            return true;

        }
        else
        {
            //isBlocking = false;
            return false;
        }
    }
}
