using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnAttackingGameObject : MonoBehaviour
{
    public Collider2D[] collider;
    public GameObject canTakeCirle;
    private ObjectClicker objectClicker;

    //also includes "CanTakeCircle(Clone) (UnityEngine.BoxCollider2D)" which causes takeCircle to appear when to pawns are facing each other. -> may cause other bugs.
    //"CanTakeCircle(Clone) (UnityEngine.BoxCollider2D)", 
    private string[] blackPieces = {"PowerUpSqaure(Clone) (UnityEngine.CircleCollider2D)", "chess-pawn-black(Clone) (UnityEngine.BoxCollider2D)", "chess-bishop-black(Clone) (UnityEngine.BoxCollider2D)", "chess-knight-black(Clone) (UnityEngine.BoxCollider2D)", "chess-king-black(Clone) (UnityEngine.BoxCollider2D)", "chess-rook-black(Clone) (UnityEngine.BoxCollider2D)", "chess-queen-black(Clone) (UnityEngine.BoxCollider2D)" };
    private string[] whitePieces = {"PowerUpSqaure(Clone) (UnityEngine.CircleCollider2D)", "chess-pawn-white(Clone) (UnityEngine.BoxCollider2D)", "chess-bishop-white(Clone) (UnityEngine.BoxCollider2D)", "chess-knight-white(Clone) (UnityEngine.BoxCollider2D)", "chess-king-white(Clone) (UnityEngine.BoxCollider2D)", "chess-rook-white(Clone) (UnityEngine.BoxCollider2D)", "chess-queen-white(Clone) (UnityEngine.BoxCollider2D)"};

    private bool attackingSameColor;

    private int debugValue;
    private void Awake()
    {
        objectClicker = FindObjectOfType<ObjectClicker>();
    }


    public void Start()
    {
        //attacks same color.

        //[0] == is self, [1] == attacking piece
        //[0] == is self, [1] == powerup square, [2] == attacking piece

        collider = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 1f);

        if(objectClicker.colorOfPieceClicked == "white")
        {
            OnClickPawnAttack(whitePieces);
        }

        if (objectClicker.colorOfPieceClicked == "black")
        {
            OnClickPawnAttack(blackPieces);
        }
    }

    private void OnClickPawnAttack(string[] colorPieces)
    {
        if (collider.Length == 1)
        {
            //Destroy(gameObject);
            return;
        }

        if (collider.Length == 2)
        {
            
            CantAttackSameColor(colorPieces);

            if (!attackingSameColor)
            {
                Instantiate(canTakeCirle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -3), Quaternion.identity);
                canTakeCirle.tag = $"canTakeCircle: {debugValue}";
            }
            Destroy(gameObject);
            return;
        }
        //its a powerup square. cant take.
        if (collider.Length == 3)
        {
            //Destroy(gameObject);
            return;
        }
    }

    private void PawnAttackingBug()
    {
        if(collider[1].ToString() == "isPawnAttacking(Clone) (UnityEngine.CircleCollider2D)")
        {
            return;
        }
    }

    private void CantAttackSameColor(string[] piecesColor)
    {
        attackingSameColor = false;
        foreach (string piece in piecesColor)
        {
            if (collider[1].ToString() == piece)
            {
                debugValue += 1;
                attackingSameColor = true;
                return;
            }
        }
    }
}
