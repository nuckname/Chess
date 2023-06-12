using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private GirdManager girdManager;
    private GetTile getTile;
    private SpawnPieces spawnPieces;
    //private GirdManager girdManager;

    
    private void Awake()
    {
        girdManager = FindObjectOfType<GirdManager>();
        getTile = FindObjectOfType<GetTile>();
        spawnPieces = FindObjectOfType<SpawnPieces>();

        girdManager.GenerateChessBoard();
    }
    private void Start()
    {
        spawnPieces.GeneratePieces();
        getTile.GeneratePowerUpTile();
    }
    
}
