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

    private CanTakePiece canTakePiece;

    private BishopPiece bishopPiece;
    private KnightPiece knightPiece;
    private RookPiece rookPiece;
    private PawnPiece pawnPiece;
    private QueenPiece queenPiece;
    private KingPiece kingPiece;

    private ClearPreviousSelection clearPreviousSelection;

    private void Awake()
    {
        clearPreviousSelection = FindObjectOfType<ClearPreviousSelection>();
        canTakePiece = FindObjectOfType<CanTakePiece>();
    }
    private void Start()
    {
        gridManager = FindObjectOfType<GirdManager>();
        locationOfTiles = gridManager.tiles;
        
    }

    public void selectedPiece(RaycastHit2D hit)
    {
        print("last clicked: " + lastClicked);

        if (hit)
        {
            // handle null case here
            print("hit");
        }

        Vector3 pos = hit.collider.transform.position;
        
        clearPreviousSelection.ClearPreviousClick(lastClicked, currentHighlightSquare);

        if (hit.collider.gameObject)
        {
            currentHighlightSquare = Instantiate(highlightSquare, new Vector3(pos.x, pos.y, -3), Quaternion.identity);
            print(hit.collider.gameObject);
        }

        if (hit.collider.gameObject.tag == "CanMoveCircle")
        {
            MovePiece(pos);
            //canTakePiece.TakePiece(pos, lastClicked);
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

        else if (hit.collider.gameObject.tag.Contains("Queen"))
        {
            HandleQueenPiece(pos, hit);
        }

        else if (hit.collider.gameObject.tag.Contains("King"))
        {
            HandleKingPiece(pos, hit);
        }
    }

    private void MovePiece(Vector2 pos)
    {
        //currentHighlightSquare = Instantiate(highlightSquare, new Vector3(position.x, position.y, -3), Quaternion.identity);
        lastClicked.transform.position = new Vector3(pos.x, pos.y, -3);
    }

    //remove -> passing in locationOfTiles. extremely taxing.
    private void HandleKnightPiece(Vector3 position, RaycastHit2D hit)
    {
        lastClicked = hit.collider.gameObject;
        knightPiece = FindObjectOfType<KnightPiece>();
        knightPiece.OnPieceClickKnight(position);
        //so how need to turn this to false maybe on last clicked or something? just go through all of them to false. like 6 lines of code.
        //knightPiece.onCollisionDestroy = true;
    }

    private void HandleBishopPiece(Vector3 position, RaycastHit2D hit)
    {
        lastClicked = hit.collider.gameObject;
        bishopPiece = FindObjectOfType<BishopPiece>();
        bishopPiece.OnPieceClickBishop(position);
    }

    private void HandlePawnPiece(Vector3 position, RaycastHit2D hit)
    {
        lastClicked = hit.collider.gameObject;
        pawnPiece = FindObjectOfType<PawnPiece>();
        pawnPiece.OnPieceClickPawn(position);
    }

    private void HandleRookPiece(Vector3 position, RaycastHit2D hit)
    {
        lastClicked = hit.collider.gameObject;
        rookPiece = FindObjectOfType<RookPiece>();
        rookPiece.OnPieceClickRook(position);
    }

    private void HandleQueenPiece(Vector3 position, RaycastHit2D hit)
    {
        lastClicked = hit.collider.gameObject;
        queenPiece = FindObjectOfType<QueenPiece>();
        queenPiece.OnPieceClickQueen(position);
    }

    private void HandleKingPiece(Vector3 position, RaycastHit2D hit)
    {
        lastClicked = hit.collider.gameObject;
        kingPiece = FindObjectOfType<KingPiece>();
        kingPiece.OnPieceClickKing(position);
    }
    
}


