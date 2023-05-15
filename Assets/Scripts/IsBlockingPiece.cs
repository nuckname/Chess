using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBlockingPiece : MonoBehaviour
{
    /* Harder than it seems
     * -> if piece is same color -> call script
     * -> if not then call take method.
     * 
     * 
     */

    //Get colorOnPos
    /* 
     * need to tell SelectedPiece to break; so that it doesnt draw the pieces.
     * 
     * 
     * 
     */

    public bool isBlocking = false;

    public Color color;


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
