using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBlockingPiece : MonoBehaviour
{
    public float lineLength = 1.0f;
    public LayerMask collisionLayer;

    private void isBlockingPiece()
    {
        // Shoot a line forward from the position of the chess piece
        //this is for bishop, queen, rook,
        Vector3 lineStart = transform.position;
        Vector3 lineEnd = lineStart + transform.forward * lineLength;
        RaycastHit hit;

        // Check for collisions with other objects on the collisionLayer
        if (Physics.Linecast(lineStart, lineEnd, out hit, collisionLayer))
        {
            // Handle collision with other object
            Debug.Log("Collision detected with " + hit.collider.gameObject.name);
        }
    }
}
