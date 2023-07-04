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

    [SerializeField]
    private GameObject lastClicked;

    private ObjectClicker _hit;

    private BishopPiece bishopPiece;
    private KnightPiece knightPiece;
    private RookPiece rookPiece;
    private PawnPiece pawnPiece;
    private QueenPiece queenPiece;
    private KingPiece kingPiece;

    private ClearPreviousSelection clearPreviousSelection;

    private HasPieceMoved hasPieceMoved;

    private void Awake()
    {
        clearPreviousSelection = FindObjectOfType<ClearPreviousSelection>();
    }
    private void Start()
    {
        //rookPiece = rookPiece.GetComponent<RookPiece>();
        //hasPieceMoved = FindObjectOfType<HasPieceMoved>();

        //rookPiece = FindObjectOfType<RookPiece>();
        //might give wrong gameobject.
        //RookPiece = GameObject.FindGameObjectWithTag("rook");

    }

    public void selectedPiece(RaycastHit2D hit)
    {
        print("last clicked: " + lastClicked);

        if (hit)
        {
            //handle null case here
            print("hit");
        }

        Vector3 pos = hit.collider.transform.position;
        
        clearPreviousSelection.ClearPreviousClick(lastClicked, currentHighlightSquare);

        if (hit.collider.gameObject)
        {
            currentHighlightSquare = Instantiate(highlightSquare, new Vector3(pos.x, pos.y, -3), Quaternion.identity);
        }

        //moving to other script isnt working.
        if (hit.collider.gameObject.tag == "CanMoveCircle")
        {
            /*
            if(lastClicked.gameObject == rookPiece.gameObject)
            {
                print("rook pos: " + rookPiece.gameObject.transform.position);
                //rookPiece.hasPieceMoved = true;
            }
            */
            MovePiece(pos);
        }

        if(hit.collider.gameObject.tag == "PawnCanMoveCircle")
        {
            MovePiece(pos);
        }

        if (hit.collider.gameObject.tag == "CanTakeCircle")
        {
            MovePiece(pos);
        }

        else if (hit.collider.gameObject.tag.Contains("Knight"))
        {
            HandleKnightPiece(pos);
            LastClickedGameObject(hit);
        }

        else if (hit.collider.gameObject.tag.Contains("Bishop"))
        {
            HandleBishopPiece(pos);
            LastClickedGameObject(hit);
        }

        else if (hit.collider.gameObject.tag.Contains("Pawn"))
        {
            HandlePawnPiece(pos);
            LastClickedGameObject(hit);
        }

        else if (hit.collider.gameObject.tag.Contains("Rook"))
        {
            HandleRookPiece(pos);
            LastClickedGameObject(hit);
        }

        else if (hit.collider.gameObject.tag.Contains("Queen"))
        {
            HandleQueenPiece(pos);
            LastClickedGameObject(hit);
        }

        else if (hit.collider.gameObject.tag.Contains("King"))
        {
            HandleKingPiece(pos);
            LastClickedGameObject(hit);
        }
    }



    private void MovePiece(Vector2 pos)
    {
        //currentHighlightSquare = Instantiate(highlightSquare, new Vector3(position.x, position.y, -3), Quaternion.identity);
        lastClicked.transform.position = new Vector3(pos.x, pos.y, -3);
    }

    private void LastClickedGameObject(RaycastHit2D hit)
    {
        lastClicked = hit.collider.gameObject;
    }

    private void HandleKnightPiece(Vector3 position)
    {
        knightPiece = FindObjectOfType<KnightPiece>();
        knightPiece.OnPieceClickKnight(position);
    }

    public void HandleBishopPiece(Vector3 position)
    {
        bishopPiece = FindObjectOfType<BishopPiece>();
        bishopPiece.OnPieceClickBishop(position);
    }

    private void HandlePawnPiece(Vector3 position)
    {
        pawnPiece = FindObjectOfType<PawnPiece>();
        pawnPiece.OnPieceClickPawn(position);
    }

    private void HandleRookPiece(Vector3 position)
    {
        rookPiece = FindObjectOfType<RookPiece>();
        rookPiece.OnPieceClickRook(position);
    }

    private void HandleQueenPiece(Vector3 position)
    {
        queenPiece = FindObjectOfType<QueenPiece>();
        queenPiece.OnPieceClickQueen(position);
    }

    private void HandleKingPiece(Vector3 position)
    {
        kingPiece = FindObjectOfType<KingPiece>();
        kingPiece.OnPieceClickKing(position);
    }
    
}


