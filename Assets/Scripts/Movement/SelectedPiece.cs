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

    private BishopPiece bishopPiece;
    private KnightPiece knightPiece;
    private RookPiece rookPiece;
    private PawnPiece pawnPiece;

    private ClearPreviousSelection clearPreviousSelection;

    private void Awake()
    {
        clearPreviousSelection = FindObjectOfType<ClearPreviousSelection>();
    }
    private void Start()
    {
        gridManager = FindObjectOfType<GirdManager>();
        locationOfTiles = gridManager.tiles;
        
    }

    public void selectedPiece(RaycastHit2D hit)
    {
        if (hit)
        {
            // handle null case here
            print("hit");
        }

        Vector3 pos = hit.collider.transform.position;

        //call ClearPreviousSelection script

        
        clearPreviousSelection.ClearPreviousClick(lastClicked, currentHighlightSquare);

        //ClearPreviousSelection(pos);

        if (hit.collider.gameObject)
        {
            currentHighlightSquare = Instantiate(highlightSquare, new Vector3(pos.x, pos.y, -3), Quaternion.identity);
        }

        if (hit.collider.gameObject.tag == "CanMoveCircle")
        {
            MovePiece(pos);
        }

        if (hit.collider.gameObject.tag == "CanTakeCircle")
        {
            MovePiece(pos);
        }

        else if (hit.collider.gameObject.tag.Contains("Knight"))
        {
            HandleKnightPiece(pos, hit);
        }

        else if (hit.collider.gameObject.tag.Contains("Bishop"))
        {
            HandleBishopPiece(pos, hit);
        }

        else if (hit.collider.gameObject.tag.Contains("Pawn"))
        {
            HandlePawnPiece(pos, hit);
        }

        else if (hit.collider.gameObject.tag.Contains("Rook"))
        {
            HandleRookPiece(pos, hit);
        }
    }
    private void MovePiece(Vector2 pos)
    {
        //currentHighlightSquare = Instantiate(highlightSquare, new Vector3(position.x, position.y, -3), Quaternion.identity);
        lastClicked.transform.position = new Vector3(pos.x, pos.y, -3);
    }

    //moved to ClearPreviousSelection
    private void ClearPreviousSelection()
    {
        if (lastClicked != null)
        {
            ClearAllCanMoveCircles();
        }

        if (currentHighlightSquare != null)
        {
            Destroy(currentHighlightSquare);
            //Destroy(highlightSquare);

            currentHighlightSquare = null;
        }
    }

    private void ClearAllCanMoveCircles()
    {
        GameObject[] canMoveCircles = GameObject.FindGameObjectsWithTag("CanMoveCircle");
        foreach (GameObject circle in canMoveCircles)
        {
            Destroy(circle);
        }
    }
    
    private void HandleKnightPiece(Vector3 position, RaycastHit2D hit)
    {
        lastClicked = hit.collider.gameObject;
        knightPiece = FindObjectOfType<KnightPiece>();
        knightPiece.OnPieceClickKnight(position, locationOfTiles);
    }

    private void HandleBishopPiece(Vector3 position, RaycastHit2D hit)
    {
        lastClicked = hit.collider.gameObject;
        bishopPiece = FindObjectOfType<BishopPiece>();
        bishopPiece.OnPieceClickBishop(position, locationOfTiles);
    }

    private void HandlePawnPiece(Vector3 position, RaycastHit2D hit)
    {
        lastClicked = hit.collider.gameObject;
        pawnPiece = FindObjectOfType<PawnPiece>();
        pawnPiece.OnPieceClickPawn(position, locationOfTiles);
    }

    private void HandleRookPiece(Vector3 position, RaycastHit2D hit)
    {
        lastClicked = hit.collider.gameObject;
        rookPiece = FindObjectOfType<RookPiece>();
        rookPiece.OnPieceClickRook(position, locationOfTiles);
    }
}


