using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasPieceMoved : MonoBehaviour
{
    private float initialisePositionX;
    private float initialisePositionY;

    private float currentPositionX;
    private float currentPositionY;

    void Start()
    {
        initialisePositionX = gameObject.transform.position.x;
        initialisePositionY = gameObject.transform.position.y;
    }

    public bool UpdatePosition()
    {
        currentPositionX = gameObject.transform.position.x;
        currentPositionY = gameObject.transform.position.y;

        if(currentPositionX != initialisePositionX)
        {
            return true;
        }
        if (currentPositionY != initialisePositionY)
        {
            return true;
        }
        else
        {
            return false;
        }
    }




}
