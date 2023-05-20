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

    public GameObject lastClicked;

    private ObjectClicker _hit;
    //public RaycastHit2D hit;

    private BishopPiece bishopPiece;
    private KnightPiece knightPiece;
    private RookPiece rookPiece;
    private PawnPiece pawnPiece;


    private IsBlockingPiece isBlockingPiece;
    private bool isBlocking = false;

    
    private void Start()
    {
        gridManager = FindObjectOfType<GirdManager>();
        locationOfTiles = gridManager.tiles;

    }

    private void movePiece(Vector2 pos)
    {
        Destroy(currentHighlightSquare);

        lastClicked.transform.position = new Vector3(pos.x, pos.y, -3);

        GameObject[] allCanMoveCirclesOnBoard = GameObject.FindGameObjectsWithTag("CanMoveCircle");

        for (int i = 0; i < allCanMoveCirclesOnBoard.Length; i++)
        {
            Destroy(allCanMoveCirclesOnBoard[i]);

        }
        print(lastClicked);
    }

    //clean up
    public void selectedPiece(RaycastHit2D hit)
    {
        if (hit)
        {
            // handle null case here
            print("hit");
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
            movePiece(pos);
        }

        else if (hit.collider.gameObject.tag.Contains("Knight"))
        {
            lastClicked = hit.collider.gameObject;
            knightPiece = FindObjectOfType<KnightPiece>();
            knightPiece.OnPieceClickKnight(pos, locationOfTiles);

        }

        else if (hit.collider.gameObject.tag.Contains("Bishop"))
        {

            lastClicked = hit.collider.gameObject;
            bishopPiece = FindObjectOfType<BishopPiece>();
            bishopPiece.OnPieceClickBishop(pos, locationOfTiles);

        }

        else if (hit.collider.gameObject.tag.Contains("Pawn"))
        {
            lastClicked = hit.collider.gameObject;
            pawnPiece = FindObjectOfType<PawnPiece>();
            pawnPiece.OnPieceClickPawn(pos, locationOfTiles);

            Instantiate(moveableLocationCircle, new Vector3(pos.x, pos.y + -2f, -3), Quaternion.identity);
        }

        else if (hit.collider.gameObject.tag.Contains("Rook"))
        {
            lastClicked = hit.collider.gameObject;
            rookPiece = FindObjectOfType<RookPiece>();
            rookPiece.OnPieceClickRook(pos, locationOfTiles);
        }
    }
}


