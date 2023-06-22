using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopPiece : MonoBehaviour
{
    private DirectionalInput directionalInput;

    private void Awake()
    {
        directionalInput = FindObjectOfType<DirectionalInput>();
    }

    public void OnPieceClickBishop(Vector2 pos)
    {
        int[][] directions = new int[][] { new int[] { -1, -1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { 1, 1 } };

        directionalInput.drawingAttackLines(pos, directions);
    }

        /*
        public void OnPieceClickBishop(Vector2 pos)
        {
            int[][] directions = new int[][] { new int[] { -1, -1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { 1, 1 } };

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
                    moveableLocationCircle.name = $"BishopCanMoveCircle {tilePosition.x}, {tilePosition.y}";

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
        */



    }
