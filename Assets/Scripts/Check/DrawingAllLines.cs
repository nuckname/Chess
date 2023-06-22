using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingAllLines : MonoBehaviour
{
    private void Start()
    {
        //each turn it would call all pieces. 
    }

    /*Draw every piece that can move in a different color.
     * if the collilder hits an enemy king -> print check. 
     */

    /*
    private void Awake()
    {
        bishopPiece = FindObjectOfType<BishopPiece>();
        rookPiece = FindObjectOfType<RookPiece>();
    }

    public void OnPieceClickQueen(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        bishopPiece.OnPieceClickBishop(pos, locationOfTiles);
        rookPiece.OnPieceClickRook(pos, locationOfTiles);
    }

    */
}
