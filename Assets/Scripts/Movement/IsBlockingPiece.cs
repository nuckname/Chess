using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBlockingPiece : MonoBehaviour
{
    public Collider2D[] collider;

    public GameObject canTakeCirle;

    public bool isBlockingValue;
    public bool hasPieceBlocking = false;
    private ObjectClicker objectClicker;
    //move to a different script the can take stuff
    private string[] blackPieces = { "chess-pawn-black(Clone) (UnityEngine.BoxCollider2D)" };
    private string[] whitePieces = { "PowerUpSqaure(Clone) (UnityEngine.CircleCollider2D)", "chess-pawn-white(Clone) (UnityEngine.BoxCollider2D)", "chess-bishop-white(Clone) (UnityEngine.BoxCollider2D)", "chess-knight-white(Clone) (UnityEngine.BoxCollider2D)", "chess-king-white(Clone) (UnityEngine.BoxCollider2D)", "chess-rook-white(Clone) (UnityEngine.BoxCollider2D)", "chess-queen-white(Clone) (UnityEngine.BoxCollider2D)" };
    
    private string PowerUpSqaure = "PowerUpSqaure(Clone) (UnityEngine.CircleCollider2D)";
    //private bool hasAlreadyCollidered = false;

    private Vector3 posCanTakeCirle;

    private void Awake()
    {
        objectClicker = FindObjectOfType<ObjectClicker>();
    }

    public void isBlocking()
    {
        collider = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 1f);

        //put this in a method.
        if (objectClicker.colorOfPieceClicked == "black")
        {
            if (collider.Length == 1)
            {
                return;
            }
            //[0] == The Circle Collider, [1] == powerup, [2] == a piece

            else
            {
                foreach (string piece in whitePieces)
                {
                    if(collider[1].ToString() == piece)
                    {
                        posCanTakeCirle = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                        Instantiate(canTakeCirle, posCanTakeCirle, Quaternion.identity);
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
    }

}
