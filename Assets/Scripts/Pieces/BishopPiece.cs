using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private IsBlockingPiece isBlockingPiece;

    public GameObject moveableLocationCirclePrefab;

    public void OnPieceClickBishop(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        int j = 1;
        int[][] directions = new int[][] { new int[] { -1, -1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { 1, 1 } };

        foreach (int[] direction in directions)
        {
            int directionX = direction[0];
            int directionY = direction[1];

            while (locationOfTiles.ContainsKey(new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))))
            {
                moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.x, locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.y, -3), Quaternion.identity);
                moveableLocationCircle.name = ($"BishopCanMoveCircle {pos.x + (j * directionX)}, {pos.y + (j * directionY)}");

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
