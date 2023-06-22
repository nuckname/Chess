using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingPiece : MonoBehaviour
{
    private bool hasMoved;
    public GameObject moveableLocationCircle;
    private SpawningMoveableCircles spawningMoveableCircles;
    private GameObject tempMoveCircle;

    
    public void OnPieceClickKing(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        int j = 1;
        int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { -1, -1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { 1, 1 } };

        foreach (int[] direction in directions)
        {
            int directionX = direction[0];
            int directionY = direction[1];

            if(locationOfTiles.ContainsKey(new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))))
            {
                tempMoveCircle = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.x, locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.y, -3), Quaternion.identity);
                moveableLocationCircle.name = ($"BishopCanMoveCircle {pos.x + (j * directionX)}, {pos.y + (j * directionY)}");

                spawningMoveableCircles = FindObjectOfType<SpawningMoveableCircles>();
                spawningMoveableCircles.isBlocking();

                if (spawningMoveableCircles.hasPieceBlocking)
                {
                    Destroy(tempMoveCircle);
                }

                j++;
            }
            j = 1;
        }

    }


}
