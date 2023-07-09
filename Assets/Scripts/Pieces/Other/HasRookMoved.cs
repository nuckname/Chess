using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasRookMoved : MonoBehaviour
{
    private CanCastle canCastle;

    private void Awake()
    {
        canCastle = FindObjectOfType<CanCastle>();
    }

    public void CheckingRookMoved(string tag)
    {
        //looping too much.
        int amountOfRooksMoved = 0;
        //gets the left rook first then the right for both black and white.
        GameObject[] rooks = GameObject.FindGameObjectsWithTag(tag);
        Vector3[] rookPositions = new Vector3[2];
        int i = 0;
        foreach (GameObject rook in rooks)
        {
            print(rook.transform.position);
            rookPositions[i] = rook.transform.position;
            i += 1;

            //checking if both rooks have moved.
            if (rook.GetComponent<RookPiece>().hasMoved == false)
            {
                canCastle.GenerateCastleMoveCircles(rookPositions, tag, rook);

            }
            else
            {
                amountOfRooksMoved += 1;
                if (amountOfRooksMoved == 2)
                {
                    //stopCheckingChecks = true;
                    Debug.Log("both rooks have moved");
                }
            }
        }
    }
}

