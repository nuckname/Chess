using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private SpawningMoveableCircles spawningMoveableCircles;

    public GameObject moveableLocationCirclePrefab;

    public void OnPieceClickBishop(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        int j = 1;
        int[][] directions = new int[][] { new int[] { -1, -1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { 1, 1 } };

        foreach (int[] direction in directions)
        {
            int directionX = direction[0];
            int directionY = direction[1];

            //replace 8 with gridManager vars
            //while (pos.x <= 8 && pos.y <= 8 && 1 >= 1)
            //while (pos.x <= 8 && pos.y <= 8 && pos.x >= 1 && pos.y >= 1)

            //This causes a big spike in performance as the locationOfTiles has 64 elements. This is for all use of locationOfTiles.
            while (locationOfTiles.ContainsKey(new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))))
            {
                //moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.x, locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.y, -3), Quaternion.identity);
                Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.x, locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.y, -3), Quaternion.identity);
                moveableLocationCircle.name = ($"BishopCanMoveCircle {pos.x + (j * directionX)}, {pos.y + (j * directionY)}");

                spawningMoveableCircles = FindObjectOfType<SpawningMoveableCircles>();
                spawningMoveableCircles.isBlocking();

                if (spawningMoveableCircles.hasPieceBlocking)
                {
                    break;
                }

                j++;
            }
            j = 1;
        }
    }
}
