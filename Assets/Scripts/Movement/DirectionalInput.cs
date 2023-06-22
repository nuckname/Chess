using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalInput : MonoBehaviour
{
    private SpawningMoveableCircles spawningMoveableCircles;
    private GirdManager gridManager;
    private bool tileFound;

    public GameObject moveableLocationCircle;
    private void Awake()
    {
        gridManager = FindObjectOfType<GirdManager>();
    }

    public void drawingAttackLines(Vector2 pos, int[][] directions)
    {
        foreach (int[] direction in directions)
        {
            int directionX = direction[0];
            int directionY = direction[1];
            int j = 1;

            Vector2 tilePosition = new Vector2(pos.x + (j * directionX), pos.y + (j * directionY));
            Tile tile = gridManager.GetTileAtPosition(tilePosition);

            while (tile != null)
            {
                Instantiate(moveableLocationCircle, new Vector3(tile.transform.position.x, tile.transform.position.y, -3), Quaternion.identity);

                //this is blocking, scripted is name wrong.
                //im getting this object too much.
                spawningMoveableCircles = FindObjectOfType<SpawningMoveableCircles>();
                spawningMoveableCircles.isBlocking();

                if (spawningMoveableCircles.hasPieceBlocking)
                {
                    break;
                }

                j++;
                tilePosition = new Vector2(pos.x + (j * directionX), pos.y + (j * directionY));
                tile = gridManager.GetTileAtPosition(tilePosition);
            }
        }
    }
}
