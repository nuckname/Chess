using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private IsBlockingPiece isBlockingPiece;
    private Collider2D[] _collider;
    private ObjectClicker objectClicker;

    //why are there two?
    public GameObject moveableLocationCirclePrefab;

    private void pawnMovementBlack(bool allowedDoubleMove, Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        int moveDistance = allowedDoubleMove ? 2 : 1; 
        print("Move Distance = " + moveDistance);
        for (int i = 1; i <= moveDistance; i++)
        {
            Vector2 targetPos = new Vector2(pos.x, pos.y - i);

            print("targetPos.y: " + targetPos.y);

            if (locationOfTiles.ContainsKey(targetPos)) 
            {
                Vector3 targetPosition = locationOfTiles[targetPos].transform.position;
                Instantiate(moveableLocationCircle, new Vector3(targetPosition.x, targetPosition.y, -3), Quaternion.identity);
            }
        }
    }

    //different is pos.y + 1. fix later
    private void pawnMovementWhite(bool allowedDoubleMove, Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        int moveDistance = allowedDoubleMove ? 2 : 1;
        print("Move Distance = " + moveDistance);
        for (int i = 1; i <= moveDistance; i++)
        {
            Vector2 targetPos = new Vector2(pos.x, pos.y + i);

            print("targetPos.y: " + targetPos.y);

            if (locationOfTiles.ContainsKey(targetPos))
            {
                Vector3 targetPosition = locationOfTiles[targetPos].transform.position;
                Instantiate(moveableLocationCircle, new Vector3(targetPosition.x, targetPosition.y, -3), Quaternion.identity);
            }
        }
    }

    public void OnPieceClickPawn(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        objectClicker = FindObjectOfType<ObjectClicker>();

        if(objectClicker.colorOfPieceClicked == "white")
        {
            if (pos.y == 1)
            {
                pawnMovementWhite(true, pos, locationOfTiles);

            }
            else
            {
                pawnMovementWhite(false, pos, locationOfTiles);
            }
        }

        else if (objectClicker.colorOfPieceClicked == "black")
        {
            if(pos.y == 6)
            {
                pawnMovementBlack(true, pos, locationOfTiles);
                
            }
            else
            {
                pawnMovementBlack(false, pos, locationOfTiles);
            }
        }
    }
}
