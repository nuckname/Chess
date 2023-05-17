using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBlockingPiece : MonoBehaviour
{
    /* Harder than it seems
     * -> if piece is same color -> call script
     * -> if not then call take method.
     * 
     * https://www.youtube.com/watch?v=t2Cs71rDlUg&t=216s
     * https://docs.unity3d.com/ScriptReference/Physics2D.OverlapBox.html
     */

    //Get colorOnPos
    /* 
     * ordering is wrong -> creating all movalbe objects then we delete them?
     * 
     * 
     * 
     */
    public Collider2D[] collider;

    public bool isBlocking = false;

    public Color color;
    private void Start()
    {
        collider = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 1);
        //print("start:"+ collider[1].ToString() + ":end");

        //use tags later.
        if(collider.Length == 2)
        {
            isBlocking = true;
            Destroy(this.gameObject);
            /*
            if (collider[0].ToString() == "CanMoveCircle(Clone) (UnityEngine.CircleCollider2D)")
            {
                print("in if");
                if (collider[1].ToString() == "chess-pawn-black(Clone) (UnityEngine.CircleCollider2D)")
                {
                    isBlocking = true;
                    print("Destroy");
                    Destroy(gameObject);
                }
            }*/
        }
        }

        private void Update()
    {



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("first line of ONCollision");
        //if piece clicked == black and a collicion == Contains.blackPawnTag; then its blocking

        //if(collision.collider.gameObject)
        if (collision.collider.CompareTag("BlackPawn"))
        {
            print("BlackPawn is blocking");
            isBlocking = true;
        }
        else
        {
            print("nothing is colliding");
        }
        if (collision.gameObject.CompareTag("BlackPawn"))
        {
            Debug.Log("Collision detected between " + gameObject.name + " and " + collision.gameObject.name);
            // Add your code for handling the collision here
        }

    }
    
}
