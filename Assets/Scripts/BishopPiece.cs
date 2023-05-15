using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private IsBlockingPiece isBlockingPiece;

    //private bool isBlocking = false;
    public bool isBlocking;

    private void Awake()
    {
        //this is also on the MoveableCircle prefab -> causing bug?
        isBlockingPiece = FindObjectOfType<IsBlockingPiece>();
        isBlocking = isBlockingPiece.isBlocking;
        print(isBlocking);
    }

    //Method name doesnt make sense.
    public void OnPieceClick(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        if (hit.collider == null)
        {
            print("hit collider null");
        }

        //also need to get for a piece collision eg blocking its view.
        //bot right line isnt working
        //looping one more time than it should be casuing an outofbounds error.
        
        int j = 1;
        while (locationOfTiles.ContainsKey(new Vector2(pos.x - j, pos.y - j)))
        {
            Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - j, pos.y - j)].transform.position.x, locationOfTiles[new Vector2(pos.x - j, pos.y - j)].transform.position.y, -3), Quaternion.identity);
            j++;
        }

        isBlocking = false;
        j = 1;
        while (locationOfTiles.ContainsKey(new Vector2(pos.x + j, pos.y - j)))
        {
            /*
            if (isBlocking)
            {
                print("isBlocking: true");
                break;
            }*/
            Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + j, pos.y - j)].transform.position.x, locationOfTiles[new Vector2(pos.x + j, pos.y - j)].transform.position.y, -3), Quaternion.identity);
            j++;
        }

        j = 1;
        //this one gives error, 1,8
        while (locationOfTiles.ContainsKey(new Vector2(pos.x + j, pos.y - j)))
        { 
            Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - j, pos.y + j)].transform.position.x, locationOfTiles[new Vector2(pos.x - j, pos.y + j)].transform.position.y, -3), Quaternion.identity);
            j++;
        }

        j = 1;
        while (locationOfTiles.ContainsKey(new Vector2(pos.x + j, pos.y - j)))
        {

            Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + j, pos.y + j)].transform.position.x, locationOfTiles[new Vector2(pos.x + j, pos.y + j)].transform.position.y, -3), Quaternion.identity);
            j++;
        }
        
    }
}
