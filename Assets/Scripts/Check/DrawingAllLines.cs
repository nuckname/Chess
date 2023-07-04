using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingAllLines : MonoBehaviour
{
    //for check.
    GameObject[] blackPawns;

    private SelectedPiece selectedPiece;
    //this should go in game Gamaer and then be passed into this script. cleaner
    private void Start()
    {
        blackPawns = GameObject.FindGameObjectsWithTag("BlackBishop");
        
    }

    //call HandleBishopPiece from selectedPiece script

    /*Draw every piece that can move in a different color.
     * if the collilder hits an enemy king -> print check. 
     */

    /*
    private void Awake()
    {
        bishopPiece = FindObjectOfType<BishopPiece>();12
        rookPiece = FindObjectOfType<RookPiece>();
    }

    public void OnPieceClickQueen(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        bishopPiece.OnPieceClickBishop(pos, locationOfTiles);
        rookPiece.OnPieceClickRook(pos, locationOfTiles);
    }

    */
}
