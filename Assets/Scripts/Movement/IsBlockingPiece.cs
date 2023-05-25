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
    private string[] whitePieces = { "chess-pawn-white(Clone) (UnityEngine.BoxCollider2D)", "chess-bishop-white(Clone) (UnityEngine.BoxCollider2D)", "chess-knight-white(Clone) (UnityEngine.BoxCollider2D)", "chess-king-white(Clone) (UnityEngine.BoxCollider2D)", "chess-rook-white(Clone) (UnityEngine.BoxCollider2D)", "chess-queen-white(Clone) (UnityEngine.BoxCollider2D)" };

    //private bool hasAlreadyCollidered = false;

    private Vector3 posCanTakeCirle;

    private void Awake()
    {
        objectClicker = FindObjectOfType<ObjectClicker>();
    }

    public void isBlocking()
    {
        collider = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 1f);

        if (objectClicker.colorOfPieceClicked == "black")
        {
            if (collider.Length == 1)
            {
                print("skip");
            }
            else
            {
                //change the foreach loop when refactor into method.
                foreach (string piece in whitePieces)
                {
                    if(collider[1].ToString() == piece)
                    {
                        posCanTakeCirle = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                        Instantiate(canTakeCirle, posCanTakeCirle, Quaternion.identity);
                        //hasAlreadyCollidered = true;
                        Destroy(gameObject);
                        break;
                    }
                    else
                    {
                        //this is being called too many times however whenever i break it goes to this (outside of the loop)
                        hasPieceBlocking = true;
                        Destroy(gameObject);
                    }
                }
            }
            
        }
    }

}
