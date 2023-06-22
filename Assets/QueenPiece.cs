using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenPiece : MonoBehaviour
{
    private BishopPiece bishopPiece;
    private RookPiece rookPiece;
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

}
