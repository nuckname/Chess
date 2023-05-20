using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private IsBlockingPiece isBlockingPiece;
    private Collider2D[] _collider;

    public GameObject moveableLocationCirclePrefab;

    //private bool isBlocking = false;
    public bool isBlock;

    private IsBlockingPiece test;
    private IsBlockingPiece isBlockingValue;


    //Method name doesnt make sense.
    public void OnPieceClickRook(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        //note gives null error when rb pushed out piece by 0.01 -> not found in dictionary.
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider == null)
        {
            print("hit collider null");
        }

        /*
        for(int i = 0; i < pos.x + 8; i++)
        {
            try
            {
                moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - i, pos.y)].transform.position.x, locationOfTiles[new Vector2(pos.x - i, pos.y)].transform.position.y, -3), Quaternion.identity);
                moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x, pos.y + i)].transform.position.x, locationOfTiles[new Vector2(pos.x, pos.y + i)].transform.position.y, -3), Quaternion.identity);
                moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x, pos.y - i)].transform.position.x, locationOfTiles[new Vector2(pos.x, pos.y - i)].transform.position.y, -3), Quaternion.identity);
                moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + i, pos.y)].transform.position.x, locationOfTiles[new Vector2(pos.x + 1, pos.y)].transform.position.y, -3), Quaternion.identity);

            }

            catch (KeyNotFoundException)
            {
                print("dw");
            }

        }
        */

        for (int i = 0; i < pos.x + 8; i++)
        {
            try
            {
                if (locationOfTiles.ContainsKey(new Vector2(pos.x - i, pos.y)))
                {
                    Vector3 targetPosition = locationOfTiles[new Vector2(pos.x - i, pos.y)].transform.position;
                    moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(targetPosition.x, targetPosition.y, -3), Quaternion.identity);
                }

                if (locationOfTiles.ContainsKey(new Vector2(pos.x, pos.y + i)))
                {
                    Vector3 targetPosition = locationOfTiles[new Vector2(pos.x, pos.y + i)].transform.position;
                    moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(targetPosition.x, targetPosition.y, -3), Quaternion.identity);
                }

                if (locationOfTiles.ContainsKey(new Vector2(pos.x, pos.y - i)))
                {
                    Vector3 targetPosition = locationOfTiles[new Vector2(pos.x, pos.y - i)].transform.position;
                    moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(targetPosition.x, targetPosition.y, -3), Quaternion.identity);
                }

                if (locationOfTiles.ContainsKey(new Vector2(pos.x + i, pos.y)))
                {
                    Vector3 targetPosition = locationOfTiles[new Vector2(pos.x + i, pos.y)].transform.position;
                    moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(targetPosition.x, targetPosition.y, -3), Quaternion.identity);
                }
            }
            catch (KeyNotFoundException)
            {

            }
        }


    }
}
