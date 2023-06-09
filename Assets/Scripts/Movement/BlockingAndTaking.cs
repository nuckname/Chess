using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingAndTaking : MonoBehaviour
{
    //blockingAndTakingPieceSpawningCircleScript.
    public Collider2D[] collider;

    public GameObject canTakeCirle;

    public bool isBlockingValue;
    public bool hasPieceBlocking = false;
    private ObjectClicker objectClicker;
    private string[] whitePieces = { "PowerUpSqaure(Clone) (UnityEngine.CircleCollider2D)", "chess-pawn-white(Clone) (UnityEngine.BoxCollider2D)", "chess-bishop-white(Clone) (UnityEngine.BoxCollider2D)", "chess-knight-white(Clone) (UnityEngine.BoxCollider2D)", "chess-king-white(Clone) (UnityEngine.BoxCollider2D)", "chess-rook-white(Clone) (UnityEngine.BoxCollider2D)", "chess-queen-white(Clone) (UnityEngine.BoxCollider2D)" };
    private string[] blackPieces = { "PowerUpSqaure(Clone) (UnityEngine.CircleCollider2D)", "chess-pawn-black(Clone) (UnityEngine.BoxCollider2D)", "chess-bishop-black(Clone) (UnityEngine.BoxCollider2D)", "chess-knight-black(Clone) (UnityEngine.BoxCollider2D)", "chess-king-black(Clone) (UnityEngine.BoxCollider2D)", "chess-rook-black(Clone) (UnityEngine.BoxCollider2D)", "chess-queen-black(Clone) (UnityEngine.BoxCollider2D)" };
    
    private Vector3 posCanTakeCirle;

    private void Awake()
    {
        objectClicker = FindObjectOfType<ObjectClicker>();
    }

    public void addColliderBoxes()
    {
        collider = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.5F, 0.5f), 0.5f);
    }

    public void isBlocking()
    {
        //collider = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.5F, 0.5f), 0.5f);

        //put this in a method.
        if (objectClicker.colorOfPieceClicked == "black")
        {
            BlockingCalculator(whitePieces);
        }

        if (objectClicker.colorOfPieceClicked == "white")
        {
            BlockingCalculator(blackPieces);
        }
    }

    public void pawnFrontMoveCircleBlocking()
    {
        if (collider.Length == 2)
        {
            Destroy(gameObject);
        }
    }

    private void BlockingCalculator(string[] piecesColor)
    {
        if (collider.Length == 1)
        {
            return;
        }
        //[0] = The Circle Collider, [1] = powerup, [2] = a piece
        //if the same colored piece and a powerup square are on the same tile it should attack
        if (collider.Length == 3)
        {
            Destroy(gameObject);
            hasPieceBlocking = true;
        }
        //this is actualy destroying the pieces.
        if(collider.Length == 2)
        {
            ReplaceMoveCircleWithTakeCircle(piecesColor);
        }
    }

    private void ReplaceMoveCircleWithTakeCircle(string[] piecesColor)
    {
        foreach (string piece in piecesColor)
        {
            if (collider[1].ToString() == piece)
            {
                posCanTakeCirle = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                Instantiate(canTakeCirle, posCanTakeCirle, Quaternion.identity);
                hasPieceBlocking = true;
                Destroy(gameObject);
                return;
            }
            else
            {
                hasPieceBlocking = true;
                Destroy(gameObject);
            }
        }
    }
}
