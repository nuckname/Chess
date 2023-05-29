using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private IsBlockingPiece isBlockingPiece;
    private Collider2D[] _collider;

    //Method name doesnt make sense.
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
                    Instantiate(moveableLocationCircle, new Vector3(targetPosition.x, targetPosition.y, -3), Quaternion.identity);

                    /*
                    isBlockingPiece = FindObjectOfType<IsBlockingPiece>();
                    isBlockingPiece.isBlocking();

                    if (isBlockingPiece.hasPieceBlocking)
                    {
                        print("break");
                        break;
                    }*/
                }
            }
            catch (KeyNotFoundException)
            {
                print("error");
            }
        }



    }
}
