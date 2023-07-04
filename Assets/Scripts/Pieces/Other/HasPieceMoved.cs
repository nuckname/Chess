using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasPieceMoved : MonoBehaviour
{
    private RookPiece rookPiece;

    private void Awake()
    {
        rookPiece = FindObjectOfType<RookPiece>();
    }

    public void PieceHasMoved(GameObject lastClicked, GameObject pieceClicked)
    {
        if (pieceClicked.CompareTag("Rook"))
        {
            print("rook has moved");
            rookPiece.hasPieceMoved = true;
            print(rookPiece.hasPieceMoved);
        }
    }
}
