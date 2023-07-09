using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanCastle : MonoBehaviour
{
    private ObjectClicker objectClicker;
    private HasRookMoved hasRookMoved;

    private bool kingOnCorrectSquare;

    public Vector2 KingPosition;


    private void Awake()
    {
        objectClicker = FindObjectOfType<ObjectClicker>();
    }
    public void Castling()
    {
        if (objectClicker.colorOfPieceClicked == "white")
        {
            kingOnCorrectSquare = KingOnCorrectSquare("white");
            if (kingOnCorrectSquare)
            {
                hasRookMoved.CheckingRookMoved("WhiteRook");
            }
        }
        if (objectClicker.colorOfPieceClicked == "black")
        {
            kingOnCorrectSquare = KingOnCorrectSquare("black");
            if (kingOnCorrectSquare)
            {
                hasRookMoved.CheckingRookMoved("BlackRook");
            }
        }
    }

    private bool KingOnCorrectSquare(string color)
    {
        if (color == "white" && KingPosition == new Vector2(4, 0))
        {
            return true;
        }

        else if (color == "black" && KingPosition == new Vector2(4, 7))
        {
            return true;
        }
        else
        {
            return false;
        }

    }



    public void GenerateCastleMoveCircles(Vector3[] rookPosition, string color, GameObject rook)
    {
        if (tag == "WhiteKing")
        {
            if (rook.transform.position == new Vector3(0, 0, -3))
            {
                //Left Rook
                //spawn castle circle
                print("white left rook can castle.");

            }

            if (rook.transform.position == new Vector3(7, 0, -3))
            {
                //Right Rook
                //spawn castle circle
                //use tag and put it in selectedPiece.
                print("white right rook can castle.");

            }


        }

        if (tag == "BlackKing")
        {
            if (rook.transform.position == new Vector3(0, 7, -3))
            {
                print("black left rook can castle.");

                //spawn casle circle.
            }

            if (rook.transform.position == new Vector3(7, 7, -3))
            {
                print("black right rook can castle.");

                //spawn casle circle.
            }
        }
    }
    //need to make sure pieces are clear.
    /* Can i just spawn move circles and if one gets destory there is a piece in the way?
     * 
     * 
     */

    private void CheckingEmptySpaceBetweenPieces()
    {

    }
}
