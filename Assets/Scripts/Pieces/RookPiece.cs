using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private IsBlockingPiece isBlockingPiece;
    private Collider2D[] _collider;

    public GameObject moveableLocationCirclePrefab;

    //private bool isBlocking = false;
    public bool isBlock;

    private IsBlockingPiece test;
    private IsBlockingPiece isBlockingValue;

    public void OnPieceClickRook(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        /*
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider == null)
        {
            print("hit collider null");
        }
        */

        Vector2[] movementOffsets = new Vector2[]
        {
            new Vector2(-1, 0),   // Left
            new Vector2(1, 0),    // Right
            new Vector2(0, 1),    // Up
            new Vector2(0, -1)    // Down
        };

        for (int i = 0; i < pos.x + 8; i++)
        {
            try
            {
                foreach (var offset in movementOffsets)
                {
                    Vector2 newPosition = new Vector2(pos.x + (i * offset.x), pos.y + (i * offset.y));

                    if (locationOfTiles.ContainsKey(newPosition))
                    {
                        Vector3 targetPosition = locationOfTiles[newPosition].transform.position;
                        moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(targetPosition.x, targetPosition.y, -3), Quaternion.identity);

                        isBlockingPiece = FindObjectOfType<IsBlockingPiece>();
                        isBlockingPiece.isBlocking();

                        
                        if (isBlockingPiece.hasPieceBlocking)
                        {
                            print("break");
                            break;
                        }
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                // Handle KeyNotFoundException if necessary
            }
        }
    }
}
