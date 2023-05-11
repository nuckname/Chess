using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;

    //Would make code clearer however not necessary and doesnt work.
    /*
     *
    private GameObject CalculateBishipLine(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles, int xValue, int yValue)
    {
        GameObject test1 = null;
        xValue = 1;
        yValue = 1;
        while (locationOfTiles.ContainsKey(new Vector2(pos.x - xValue, pos.y - yValue)))
        {
            test1 = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - xValue, pos.y - yValue)].transform.position.x, locationOfTiles[new Vector2(pos.x - xValue, pos.y - yValue)].transform.position.y, -3), Quaternion.identity);
            xValue++;
            yValue++;
        }
        return test1;
    }*/

    private IsBlockingPiece isBlockingPiece;
    private bool isBlocking = false;


    private void Awake()
    {
        isBlockingPiece = FindObjectOfType<IsBlockingPiece>();
    }

    private void CalculateBishipLine(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles, int xValue, int yValue)
    {
        /*
        while (locationOfTiles.ContainsKey(new Vector2(pos.x + xValue, pos.y + yValue)))
        {
            Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + xValue, pos.y + yValue)].transform.position.x, locationOfTiles[new Vector2(pos.x + xValue, pos.y + yValue)].transform.position.y, -3), Quaternion.identity);
            xValue++;
            yValue++;
        }
        */
        while (locationOfTiles.ContainsKey(new Vector2(pos.x + xValue, pos.y + yValue)))
        {
            Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + xValue, pos.y + yValue)].transform.position.x, locationOfTiles[new Vector2(pos.x + xValue, pos.y + yValue)].transform.position.y, -3), Quaternion.identity);
            xValue++;
            yValue++;
        }
    }
    public void OnPieceClick(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        //CalculateBishipLine(pos, locationOfTiles, -1, -1);
        //CalculateBishipLine(pos, locationOfTiles, -1, -1);
        /*
        print("1");
        CalculateBishipLine(pos, locationOfTiles, +1, -1);

        print("1");
        CalculateBishipLine(pos, locationOfTiles, -1, +1);
        print("1");
        
        CalculateBishipLine(pos, locationOfTiles, +1, +1);
        */
        //also need to get for a piece collision eg blocking its view.

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        print("hello");
        
        if (hit.collider == null)
        {
            print("hit collider null");
        }
        

        //lastClicked = hit.collider.gameObject;
        
        //also need to get for a piece collision eg blocking its view.
        
        int j = 1;
        while (locationOfTiles.ContainsKey(new Vector2(pos.x - j, pos.y - j)))
        {
            Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - j, pos.y - j)].transform.position.x, locationOfTiles[new Vector2(pos.x - j, pos.y - j)].transform.position.y, -3), Quaternion.identity);
            //isBlocking = isBlockingPiece.OnTriggerEnter2D()


            j++;
        }

        j = 1;
        while (locationOfTiles.ContainsKey(new Vector2(pos.x + j, pos.y - j)))
        {
            Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + j, pos.y - j)].transform.position.x, locationOfTiles[new Vector2(pos.x + j, pos.y - j)].transform.position.y, -3), Quaternion.identity);

            j++;
        }

        j = 1;
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
