using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPiece : MonoBehaviour
{
    public GameObject highlightSquare;
    private GameObject currentHighlightSquare;

    public GameObject moveableLocationCircle;

    public GameObject takeLocationSquare;

    private GirdManager gridManager;

    public Dictionary<Vector2, Tile> locationOfTiles;

    private GameObject lastClicked;

    private ObjectClicker _hit;
    //public RaycastHit2D hit;

    private BishopPiece bishopPiece;

    private IsBlockingPiece isBlockingPiece;
    private bool isBlocking = false;

    /*
    private void Awake()
    {
        bishopPiece = FindObjectOfType<BishopPiece>();
    }
    */
    private void Start()
    {
        //update?
        
        //isBlockingPiece = FindObjectOfType<IsBlockingPiece>();
        //isBlocking = isBlockingPiece.isBlocking;

        gridManager = FindObjectOfType<GirdManager>();
        locationOfTiles = gridManager.tiles;

        //_hit = FindObjectOfType<ObjectCliker>();
        //hit = _hit.hit;
    }

    //clean up
    public void selectedPiece(RaycastHit2D hit)
    {
        if (hit)
        {
            // handle null case here
            print("error");
        }

        Vector3 pos = hit.collider.transform.position;

        if (currentHighlightSquare != null)
        {
            Destroy(currentHighlightSquare);
            currentHighlightSquare = null;
        }

        if (hit.collider.gameObject)
        {
            currentHighlightSquare = Instantiate(highlightSquare, new Vector3(pos.x, pos.y, -3), Quaternion.identity);
        }

        if (hit.collider.gameObject.tag == "CanMoveCircle")
        {
            
            Destroy(currentHighlightSquare);

            lastClicked.transform.position = new Vector3(pos.x, pos.y, -3);

            GameObject[] allCanMoveCirclesOnBoard = GameObject.FindGameObjectsWithTag("CanMoveCircle");

            for(int i = 0; i < allCanMoveCirclesOnBoard.Length; i++)
            {
                Destroy(allCanMoveCirclesOnBoard[i]);

            }
            print(lastClicked);
        }

        //If i line everything up it should be in the dictionary.
        //then just pos.x + 2 and pos.y + 1 or something for an L shaped horse movement.
        else if (hit.collider.gameObject.tag == "Knight")
        {
            lastClicked = hit.collider.gameObject;

             Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x + 1, pos.y - 2)].transform.position.x, locationOfTiles[new Vector2(pos.x + 1, pos.y - 2)].transform.position.y, -3), Quaternion.identity);
             Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x - 1, pos.y - 2)].transform.position.x, locationOfTiles[new Vector2(pos.x - 1, pos.y - 2)].transform.position.y, -3), Quaternion.identity);

        }

        else if (hit.collider.gameObject.tag == "Bishop")
        {
            //also need to get for a piece collision eg blocking its view.
            print(hit);
            lastClicked = hit.collider.gameObject;

            bishopPiece = FindObjectOfType<BishopPiece>();
            bishopPiece.OnPieceClick(pos, locationOfTiles);

        }

        else if (hit.collider.gameObject.tag == "Pawn")
        {
            //might need two different pawns (first two can move forward).
            print("Pawn clicked");
            Instantiate(moveableLocationCircle, new Vector3(pos.x, pos.y + -2f, -3), Quaternion.identity);
        }
    }
}


