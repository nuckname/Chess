using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookPiece : MonoBehaviour
{
    [SerializeField]
    private bool hasMoved;

    public GameObject moveableLocationCircle;
    private SpawningMoveableCircles spawningMoveableCircles;
    private Collider2D[] _collider;

    public GameObject moveableLocationCirclePrefab;
    
    public bool isBlock;

    public void OnPieceClickRook(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        //this code is the same as bishop but with different array values -> OOP!!!!1!

        int j = 1;
        int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };

        foreach (int[] direction in directions)
        {
            int directionX = direction[0];
            int directionY = direction[1];

            while (locationOfTiles.ContainsKey(new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))))
            {
                moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.x, locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.y, -3), Quaternion.identity);
                moveableLocationCircle.name = ($"rookCanMoveCircle {pos.x + (j * directionX)}, {pos.y + (j * directionY)}");

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
