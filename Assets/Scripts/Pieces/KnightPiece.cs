using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private SpawningMoveableCircles spawningMoveableCircles;
    private Collider2D[] _collider;

    private GameObject tempMoveableCircle;

    public void OnPieceClickKnight(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        //note gives null error when rb pushed out piece by 0.01 -> not found in dictionary.
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider == null)
        {
            print("hit collider null");
        }

        int[] offsetXValues = { -1, 1, -2, 2, -2, 2, -1, 1 };
        int[] offsetYValues = { 2, 2, -1, -1, 1, 1, -2, -2 };

        for (int i = 0; i < offsetXValues.Length; i++)
        {
            try
            {
                Vector2 tilePosition = new Vector2(pos.x + offsetXValues[i], pos.y + offsetYValues[i]);
                if (locationOfTiles.ContainsKey(tilePosition))
                {
                    Vector3 targetPosition = locationOfTiles[tilePosition].transform.position;
                    tempMoveableCircle = Instantiate(moveableLocationCircle, new Vector3(targetPosition.x, targetPosition.y, -3), Quaternion.identity);


                    spawningMoveableCircles = FindObjectOfType<SpawningMoveableCircles>();
                    spawningMoveableCircles.isBlocking();

                    if (spawningMoveableCircles.hasPieceBlocking)
                    {
                        Destroy(tempMoveableCircle);
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                print("error");
            }
        }
    }
}
