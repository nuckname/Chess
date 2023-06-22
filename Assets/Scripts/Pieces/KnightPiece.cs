using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private SpawningMoveableCircles spawningMoveableCircles;
    private Collider2D[] _collider;

    private GirdManager gridManager;
    private bool tileFound;

    private GameObject tempMoveableCircle;
    private void Awake()
    {
        gridManager = FindObjectOfType<GirdManager>();
    }

    public void OnPieceClickKnight(Vector2 pos)
    {
        //note gives null error when rb pushed out piece by 0.01 -> not found in dictionary.
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        int[] offsetXValues = { -1, 1, -2, 2, -2, 2, -1, 1 };
        int[] offsetYValues = { 2, 2, -1, -1, 1, 1, -2, -2 };

        for (int i = 0; i < offsetXValues.Length; i++)
        {
            Vector2 tilePosition = new Vector2(pos.x + offsetXValues[i], pos.y + offsetYValues[i]);
            tileFound = gridManager.GetTileAtPosition(tilePosition);

            if (tileFound)
            {
                tempMoveableCircle = Instantiate(moveableLocationCircle, new Vector3(tilePosition.x, tilePosition.y, -3), Quaternion.identity);

                spawningMoveableCircles = FindObjectOfType<SpawningMoveableCircles>();
                spawningMoveableCircles.isBlocking();

                if (spawningMoveableCircles.hasPieceBlocking)
                {
                    Destroy(tempMoveableCircle);
                }
            }
        }
    }
}
