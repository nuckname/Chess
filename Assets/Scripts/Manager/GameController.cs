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

    private GirdManager gridManager;

    public Dictionary<Vector2, Tile> locationOfTiles;

    void Start()
    {
        gridManager = FindObjectOfType<GirdManager>();
        locationOfTiles = gridManager.tiles;

        //can loop backwards but over completed
        GameObject[] backLineBlackPieces = { blackRook, blackKnight, blackBishop, blackQueen, blackKing, blackBishop, blackKnight, blackRook };
        GameObject[] backLineWhitePieces = { whiteRook, whiteKnight, whiteBishop, whiteQueen, whiteKing, whiteBishop, whiteKnight, whiteRook };

        Vector2 blackXPosFrontLine = new Vector2(0, 6);
        Vector2 blackXPosBackLine = new Vector2(0, 7);

        Vector2 whiteXPosFrontLine = new Vector2(0,1);
        Vector2 whiteXPosBackLine = new Vector2(0,0);

        SpawnPawns(blackXPosFrontLine, blackPawn);
        SpawnBackLinePieces(blackXPosBackLine, backLineBlackPieces);

        
        SpawnPawns(whiteXPosFrontLine, whitePawn);
        SpawnBackLinePieces(whiteXPosBackLine, backLineWhitePieces);

    }

    private void SpawnPawns(Vector2 pawnSpawnPos,  GameObject pawnColor)
    {
        for(int i = 0; i < 8; i++)
        {
            Instantiate(pawnColor, new Vector3(locationOfTiles[pawnSpawnPos].transform.position.x, locationOfTiles[pawnSpawnPos].transform.position.y, -3), Quaternion.identity);
            pawnSpawnPos.x += 1;
        }
    }

    private void SpawnBackLinePieces(Vector2 backlineSpawnPos, GameObject[] backlinePieces)
    {
        for(int i = 0; i < backlinePieces.Length; i++)
        {
            Instantiate(backlinePieces[i], new Vector3(locationOfTiles[backlineSpawnPos].transform.position.x, locationOfTiles[backlineSpawnPos].transform.position.y, -3), Quaternion.identity);
            
            backlineSpawnPos.x += 1;
        }

    }
}
