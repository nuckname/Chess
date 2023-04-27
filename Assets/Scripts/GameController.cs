using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject blackKing;
    public GameObject blackPawn;
    public GameObject blackBishop;
    public GameObject blackRook;
    public GameObject blackQueen;
    public GameObject blackKnight;

    public GameObject whiteKing;
    public GameObject whitePawn;
    public GameObject whiteBishop;
    public GameObject whiteRook;
    public GameObject whiteQueen;
    public GameObject whiteKnight;

    void Start()
    {
        GameObject[] backLineBlackPieces = { blackRook, blackKnight, blackBishop, blackQueen, blackKing };
        GameObject[] backLineWhitePieces = { whiteRook, whiteKnight, whiteBishop, whiteKing, whiteQueen };

        float blackXStartingPos = -4.83f;
        float whiteXStartingPos = -4.79f;

        SpawnPawns(blackXStartingPos, 3.06f, blackPawn);
        SpawnBackLinePieces(blackXStartingPos, 4.31f, backLineBlackPieces);

        
        SpawnPawns(whiteXStartingPos, -3.12f, whitePawn);
        SpawnBackLinePieces(whiteXStartingPos, -4.37f, backLineWhitePieces);
        
    }

    private void SpawnPawns(float pawnXPos, float pawnYPos, GameObject pawnColor)
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(pawnColor, new Vector3(pawnXPos, pawnYPos, -1), Quaternion.identity);
            pawnXPos = pawnXPos - -1.25f;
        }
    }

    private void SpawnBackLinePieces(float pawnXPos, float pawnYPos, GameObject[] backlinePieces)
    {
        for(int i = 0; i < backlinePieces.Length; i++)
        {
            Instantiate(backlinePieces[i], new Vector3(pawnXPos, pawnYPos, -1), Quaternion.identity);
            pawnXPos = pawnXPos - -1.25f;
        }

        for(int i = 2; i >= 0 && i >= -1; i--)
        {
            Instantiate(backlinePieces[i], new Vector3(pawnXPos, pawnYPos, -1), Quaternion.identity);
            pawnXPos = pawnXPos - -1.25f;
        }
    }
}
