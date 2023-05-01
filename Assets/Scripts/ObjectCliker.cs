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

    private void Start()
    {
        gridManager = FindObjectOfType<GirdManager>();
        Dictionary<Vector2, Tile> locationOfTiles = gridManager.tiles;

        Debug.Log("In other script");
        Debug.Log(locationOfTiles[new Vector2(2, 3)]);
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

                //snap zone?
                //if it hits anything.
                //Draw everwhere it can go
                //if it hits an object replace circle with square
                //make the hitbox for the cricle the full square of the board.
                //square can take
                //only allowed to move on cricle or sqaure.
                if(hit.collider.gameObject)
                {
                    currentHighlightSquare = Instantiate(highlightSquare, new Vector3(pos.x, pos.y, -3), Quaternion.identity);
                }

                if(hit.collider.gameObject.tag == "CanMoveCircle")
                {
                    Destroy(currentHighlightSquare);
                    lastClickedObject.transform.position = new Vector3(pos.x, pos.y, -3);
                }

                else if(hit.collider.gameObject.tag == "Knight")
                {
                    print("horse clicked");
                    //going to be different for white ot black pieces.
                    //cant use find tags becuase there are two clones of the same piece eg two bishops.
                    //PAWNS: different colour pieces will have different directional moves -> black -x white +x.can use different tags for color -> mainly pawns.

                    /*
                    //use a method.
                    lastClickedObject = hit.collider.gameObject;
                    //up right ^^
                    currentMoveableLocationCircle[0] = Instantiate(moveableLocationCircle, new Vector3(pos.x + -1.2f, pos.y + -2.55f, -3), Quaternion.identity);
                    //up left ^^
                    currentMoveableLocationCircle[1] = Instantiate(moveableLocationCircle, new Vector3(pos.x + 1.2f, pos.y + 2.55f, -3), Quaternion.identity);
                    //down right vv
                    currentMoveableLocationCircle[2] = Instantiate(moveableLocationCircle, new Vector3(pos.x + -2.55f, pos.y + 1.2f, -3), Quaternion.identity);
                   //down left vv
                    currentMoveableLocationCircle[3] = Instantiate(moveableLocationCircle, new Vector3(pos.x + 2.55f, pos.y + -1.2f, -3), Quaternion.identity);

                    currentMoveableLocationCircle[4] = Instantiate(moveableLocationCircle, new Vector3(pos.x + -0.2f, pos.y + -1.55f, -3), Quaternion.identity);

                    currentMoveableLocationCircle[5] = Instantiate(moveableLocationCircle, new Vector3(pos.x + 2.55f, pos.y + -1.2f, -3), Quaternion.identity);
                    
                    currentMoveableLocationCircle[6] = Instantiate(moveableLocationCircle, new Vector3(pos.x + 2.55f, pos.y + -1.2f, -3), Quaternion.identity);
                    
                    currentMoveableLocationCircle[7] = Instantiate(moveableLocationCircle, new Vector3(pos.x + 2.55f, pos.y + -1.2f, -3), Quaternion.identity);
                    
                    currentMoveableLocationCircle[8] = Instantiate(moveableLocationCircle, new Vector3(pos.x + 2.55f, pos.y + -1.2f, -3), Quaternion.identity);
                    
                    currentMoveableLocationCircle[9] = Instantiate(moveableLocationCircle, new Vector3(pos.x + 2.55f, pos.y + -1.2f, -3), Quaternion.identity);
                    */
                    /*
                    //Vector2 tilePosition = new Vector2(1, 1);
                    Vector2 tilePosition = locationOfTiles[1,2];
                    //Tile tile = locationOfTiles[tilePosition];
                    Vector3 spawnPosition = new Vector3(tilePosition.x, tilePosition.y, -3);
                    Instantiate(moveableLocationCircle, spawnPosition, Quaternion.identity);
                    */
                }

                else if(hit.collider.gameObject.tag == "Bishop")
                {

                }

                else if (hit.collider.gameObject.tag == "Pawn")
                {
                    
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

