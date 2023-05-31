using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private IsBlockingPiece isBlockingPiece;
    private Collider2D[] _collider;
    private ObjectClicker objectClicker;

    private void pawnMovement(bool allowedDoubleMove, Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles, int direction)
    {
        int moveDistance = allowedDoubleMove ? 2 : 1;
        for (int i = 1; i <= moveDistance; i++)
        {
            Vector2 targetPos = new Vector2(pos.x, pos.y + (direction * i));
            
            if (locationOfTiles.ContainsKey(targetPos))
            {
                //doesnt currently work.
                Vector3 targetPosition = locationOfTiles[targetPos].transform.position;
                Instantiate(moveableLocationCircle, new Vector3(targetPosition.x, targetPosition.y, -3), Quaternion.identity);
                isBlockingPiece = FindObjectOfType<IsBlockingPiece>();

                isBlockingPiece.isBlocking();

                if (isBlockingPiece.hasPieceBlocking)
                {
                    break;
                }
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
                pawnMovement(true, pos, locationOfTiles, 1);

            }
            else
            {
                pawnMovement(false, pos, locationOfTiles, 1);
            }
        }

        else if (objectClicker.colorOfPieceClicked == "black")
        {
            if(pos.y == 6)
            {
                pawnMovement(true, pos, locationOfTiles, -1);
                
            }
            else
            {
                pawnMovement(false, pos, locationOfTiles, -1);
            }
        }
    }
}
