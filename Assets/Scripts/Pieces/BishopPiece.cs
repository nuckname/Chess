using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopPiece : MonoBehaviour
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
    public void OnPieceClickBishop(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        //note gives null error when rb pushed out piece by 0.01 -> not found in dictionary.
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        if (hit.collider == null)
        {
            print("hit collider null");
        }

        int j = 1;
        int[][] directions = new int[][] { new int[] { -1, -1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { 1, 1 } };

        foreach (int[] direction in directions)
        {
            int directionX = direction[0];
            int directionY = direction[1];

            while (locationOfTiles.ContainsKey(new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))))
            {
                //not good for performance
                //isBlockingPiece = FindObjectOfType<IsBlockingPiece>();
                moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.x, locationOfTiles[new Vector2(pos.x + (j * directionX), pos.y + (j * directionY))].transform.position.y, -3), Quaternion.identity);
                

                //call script.

                /*
                print(isBlockingPiece.test);
                if(isBlockingPiece.isBlockingValue)
                {
                    break;
                }*/
                j++;
            }
            j = 1;
        }
    }
}