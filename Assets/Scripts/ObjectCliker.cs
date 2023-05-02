using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCliker : MonoBehaviour
{
    //Clicker*

    public GameObject highlightSquare;
    private GameObject currentHighlightSquare;

    private GameObject lastClickedObject;

    public GameObject moveableLocationCircle;
    //[4] is going to need to be a lot higher as the queen can move like 16+ tiles.
    private GameObject[] currentMoveableLocationCircle = new GameObject[4];

    public GameObject takeLocationSquare;

    private GirdManager gridManager;

    public Dictionary<Vector2, Tile> locationOfTiles;

    private void Start()
    {
        gridManager = FindObjectOfType<GirdManager>();
        //Dictionary<Vector2, Tile> locationOfTiles = gridManager.tiles;
        locationOfTiles = gridManager.tiles;

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
        if(Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null)
            {
                Vector3 pos = hit.collider.transform.position;

                
                if(currentHighlightSquare != null)
                {
                    Destroy(currentHighlightSquare);
                    currentHighlightSquare = null;
                }

                if(currentMoveableLocationCircle[0] != null)
                {
                    for(int i = 0; i < currentMoveableLocationCircle.Length; i++)
                    {
                        Destroy(currentMoveableLocationCircle[i]);
                    }

                    currentMoveableLocationCircle = new GameObject[27];
                    //27 possible moves form one piece.
                }
                

                if(hit.collider.gameObject)
                {
                    currentHighlightSquare = Instantiate(highlightSquare, new Vector3(pos.x, pos.y, -3), Quaternion.identity);
                }

                if(hit.collider.gameObject.tag == "CanMoveCircle")
                {
                    Destroy(currentHighlightSquare);

                    lastClickedObject.transform.position = new Vector3(pos.x, pos.y, -3);
                }

                //If i line everything up it should be in the dictionary.
                //then just pos.x + 2 and pos.y + 1 or something for an L shaped horse movement.
                else if(hit.collider.gameObject.tag == "Knight")
                {
                    lastClickedObject = hit.collider.gameObject;

                    currentMoveableLocationCircle[0] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + 1, pos.y - 2)].transform.position.x, locationOfTiles[new Vector2(pos.x + 1, pos.y - 2)].transform.position.y, -3), Quaternion.identity);
                    currentMoveableLocationCircle[1] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - 1, pos.y - 2)].transform.position.x, locationOfTiles[new Vector2(pos.x - 1, pos.y - 2)].transform.position.y, -3), Quaternion.identity);
                    
                }

                else if(hit.collider.gameObject.tag == "Bishop")
                {
                    lastClickedObject = hit.collider.gameObject;

                    int i = 0;
                    int j = 0;
                    try
                    {
                        while (true)
                        {
                            //this array is being replaced.
                            currentMoveableLocationCircle[i] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - i, pos.y - i)].transform.position.x, locationOfTiles[new Vector2(pos.x - i, pos.y - i)].transform.position.y, -3), Quaternion.identity);
                            currentMoveableLocationCircle[j] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + i, pos.y - i)].transform.position.x, locationOfTiles[new Vector2(pos.x + i, pos.y - i)].transform.position.y, -3), Quaternion.identity);
                            i++;
                            j++;
                        }
                    }
                    catch (KeyNotFoundException e)
                    {
                        // Do nothing, just exit the loop
                    }



                    /*
                    for (int i = 0; i <= 8; i++)
                    {
                        currentMoveableLocationCircle[i] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - i, pos.y - i)].transform.position.x, locationOfTiles[new Vector2(pos.x - i, pos.y - i)].transform.position.y, -3), Quaternion.identity);
                    }

                    for (int i = 0; i <= 8; i++)
                    {
                        currentMoveableLocationCircle[i] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + i, pos.y - i)].transform.position.x, locationOfTiles[new Vector2(pos.x + i, pos.y - i)].transform.position.y, -3), Quaternion.identity);
                    }
                    */
                    print(pos.x + " " + pos.y);
                    //currentMoveableLocationCircle[0] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - 1, pos.y - 1)].transform.position.x, locationOfTiles[new Vector2(pos.x - 1, pos.y - 1)].transform.position.y, -3), Quaternion.identity);
                    //currentMoveableLocationCircle[0] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + 1, pos.y - 1)].transform.position.x, locationOfTiles[new Vector2(pos.x + 1, pos.y - 1)].transform.position.y, -3), Quaternion.identity);
                    //currentMoveableLocationCircle[0] = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + 2, pos.y - 2)].transform.position.x, locationOfTiles[new Vector2(pos.x + 2, pos.y - 2)].transform.position.y, -3), Quaternion.identity);

                }

                else if (hit.collider.gameObject.tag == "Pawn")
                {
                    lastClickedObject = hit.collider.gameObject;

                    print("Pawn clicked");
                    currentMoveableLocationCircle[0] = Instantiate(moveableLocationCircle, new Vector3(pos.x, pos.y + -2f, -3), Quaternion.identity);
                }

            }
            else
            {
                print("hit.collider hit nothing");
            }
        }
    }
}

