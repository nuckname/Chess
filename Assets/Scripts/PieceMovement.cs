using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    //Clicker*

    public GameObject highlightSquare;
    private GameObject currentHighlightSquare;

    public GameObject moveableLocationCircle;
    //[4] is going to need to be a lot higher as the queen can move like 16+ tiles.
    //= new GameObject[4];
    private GameObject[] currentMoveableLocationCircle = new GameObject[4];

    public GameObject takeLocationSquare;

    private GirdManager gridManager;

    public Dictionary<Vector2, Tile> locationOfTiles;

    private ObjectCliker _lastClickedObject;
    private GameObject lastClicked;

    private ObjectCliker _hit;
    public RaycastHit2D hit;

    private void Start()
    {
        gridManager = FindObjectOfType<GirdManager>();
        //Dictionary<Vector2, Tile> locationOfTiles = gridManager.tiles;
        locationOfTiles = gridManager.tiles;

        //I dont think i need this.
        _lastClickedObject = FindObjectOfType<ObjectCliker>();
        lastClicked = _lastClickedObject.lastClickedObject;

        _hit = FindObjectOfType<ObjectCliker>();
        hit = _hit.hit;

        print(hit);
        //Instantiate(moveableLocationCircle, locationOfTiles[new Vector2(1, 2)].transform.position, Quaternion.identity);
        //Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(1, 2)].transform.position.x, locationOfTiles[new Vector2(1, 2)].transform.position.y, -3), Quaternion.identity);

        //Debug.Log(locationOfTiles.Keys);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if circle collides w/ piece -> destroy that piece and everyhing after.
    }

    private void Update()
    {

    }

    public void hello(RaycastHit2D hit)
    {
        print(hit); 
        if (hit.collider != null)
        {
            print("hello");

        }

        //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        Vector3 pos = hit.collider.transform.position;

        if (currentHighlightSquare != null)
        {
            Destroy(currentHighlightSquare);
            currentHighlightSquare = null;
        }

        if (currentMoveableLocationCircle[0] != null)
        {
            for (int i = 0; i < currentMoveableLocationCircle.Length; i++)
            {
                Destroy(currentMoveableLocationCircle[i]);
            }

            currentMoveableLocationCircle = new GameObject[27];
            //27 possible moves form one piece.
        }


        if (hit.collider.gameObject)
        {
            currentHighlightSquare = Instantiate(highlightSquare, new Vector3(pos.x, pos.y, -3), Quaternion.identity);
        }

        if (hit.collider.gameObject.tag == "CanMoveCircle")
        {
            Destroy(currentHighlightSquare);

            lastClicked.transform.position = new Vector3(pos.x, pos.y, -3);
        }

        //If i line everything up it should be in the dictionary.
        //then just pos.x + 2 and pos.y + 1 or something for an L shaped horse movement.
        else if (hit.collider.gameObject.tag == "Knight")
        {
            lastClicked = hit.collider.gameObject;

            currentMoveableLocationCircle[0] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + 1, pos.y - 2)].transform.position.x, locationOfTiles[new Vector2(pos.x + 1, pos.y - 2)].transform.position.y, -3), Quaternion.identity);
            currentMoveableLocationCircle[1] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - 1, pos.y - 2)].transform.position.x, locationOfTiles[new Vector2(pos.x - 1, pos.y - 2)].transform.position.y, -3), Quaternion.identity);

        }

        else if (hit.collider.gameObject.tag == "Bishop")
        {
            lastClicked = hit.collider.gameObject;



            //.length might be wrong as its set 2 4 only -> may cause a bugg depending on what piece is first seleceted.

            /*for(int i = 0; i < currentMoveableLocationCircle.Length; i++)
            {
                try
                {
                    while (i <= 26)
                    {
                        //this array is being replaced.
                        currentMoveableLocationCircle[i] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - i, pos.y - i)].transform.position.x, locationOfTiles[new Vector2(pos.x - i, pos.y - i)].transform.position.y, -3), Quaternion.identity);
                    }
                }
                catch (KeyNotFoundException e)
                {
                            
                }

                try
                {
                    while (i <= 26)
                    {
                        //this array is being replaced still.
                        currentMoveableLocationCircle[i] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + i, pos.y - i)].transform.position.x, locationOfTiles[new Vector2(pos.x + i, pos.y - i)].transform.position.y, -3), Quaternion.identity);

                    }
                }
                catch (KeyNotFoundException e)
                {

                }
            }*/

            //also need to get for a piece collision eg blocking its view.
            int j = 0;
            while (locationOfTiles.ContainsKey(new Vector2(pos.x - j, pos.y - j)))
            {
                currentMoveableLocationCircle[j] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - j, pos.y - j)].transform.position.x, locationOfTiles[new Vector2(pos.x - j, pos.y - j)].transform.position.y, -3), Quaternion.identity);
                j++;
            }

            print("FIRST WHILE DONE " + j);

            while (locationOfTiles.ContainsKey(new Vector2(pos.x + j, pos.y + j)))
            {
                Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + j, pos.y + j)].transform.position.x, locationOfTiles[new Vector2(pos.x + j, pos.y + j)].transform.position.y, -3), Quaternion.identity);
                j++;
            }

            print("FIRST WHILE DONE " + j);


            /*
            try
            {
                int j = 0;
                for (int i = 0; i <= 10; i++)
                {
                    currentMoveableLocationCircle[i] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - j, pos.y - j)].transform.position.x, locationOfTiles[new Vector2(pos.x - j, pos.y - j)].transform.position.y, -3), Quaternion.identity);
                    print(i);
                    print(currentMoveableLocationCircle.Length);
                    print(" ");
                    j++;
                }
            }
            catch (KeyNotFoundException e)
            {
                print(e);
                print("catch");
            }

            try
            {
                int j = 0;
                for (int i = currentMoveableLocationCircle.Length; i <= 16; i++)
                {
                    currentMoveableLocationCircle[i] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + j, pos.y - j)].transform.position.x, locationOfTiles[new Vector2(pos.x + j, pos.y - j)].transform.position.y, -3), Quaternion.identity);
                    print(i);
                    print(currentMoveableLocationCircle.Length);
                    print(" ");
                    j++;
                }
            }*/


            print(pos.x + " " + pos.y);
            //currentMoveableLocationCircle[0] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - 1, pos.y - 1)].transform.position.x, locationOfTiles[new Vector2(pos.x - 1, pos.y - 1)].transform.position.y, -3), Quaternion.identity);
            //currentMoveableLocationCircle[0] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + 1, pos.y - 1)].transform.position.x, locationOfTiles[new Vector2(pos.x + 1, pos.y - 1)].transform.position.y, -3), Quaternion.identity);
            //currentMoveableLocationCircle[0] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + 2, pos.y - 2)].transform.position.x, locationOfTiles[new Vector2(pos.x + 2, pos.y - 2)].transform.position.y, -3), Quaternion.identity);

        }

        else if (hit.collider.gameObject.tag == "Pawn")
        {
            lastClicked = hit.collider.gameObject;

            print("Pawn clicked");
            currentMoveableLocationCircle[0] = Instantiate(moveableLocationCircle, new Vector3(pos.x, pos.y + -2f, -3), Quaternion.identity);
        }

        
    }
}


