using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private IsBlockingPiece isBlockingPiece;

    public GameObject moveableLocationCirclePrefab;

    //Method name doesnt make sense.
    public void OnPieceClickBishop(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        /*
         * RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        if (hit.collider == null)
        {
            print("hit collider null");
        }
        */

        int j = 1;
        int[][] directions = new int[][] { new int[] { -1, -1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { 1, 1 } };

        foreach (int[] direction in directions)
        {
            int directionX = direction[0];
            int directionY = direction[1];

            while (locationOfTiles.ContainsKey(new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))))
            {
                moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.x, locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.y, -3), Quaternion.identity);
                moveableLocationCircle.name = ($"CanMoveCircle {pos.x + (j * directionX)}, {pos.y + (j * directionY)}");

                isBlockingPiece = FindObjectOfType<IsBlockingPiece>();
                isBlockingPiece.isBlocking();

                if(isBlockingPiece.hasPieceBlocking)
                {
                    print("break");
                    break;
                }

                j++;
            }
            j = 1;
        }
    }
}
