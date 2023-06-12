using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTile : MonoBehaviour
{
    public GameObject DebugPowerUp;

    private GirdManager gridManager;
    private Tile tile;
    private void Awake()
    {
        gridManager = FindObjectOfType<GirdManager>();
    }
    //public GridMan
    //Gets random tile and passes it
    public void GeneratePowerUpTile()
    {
        System.Random randomTilePos = new System.Random();
        //just for debugging
        int RandomrandomTilePosX = randomTilePos.Next(0, gridManager.xHeight);
        int RandomrandomTilePosY = randomTilePos.Next(0, gridManager.yHeight);
        Vector2 tilePosition = new Vector2(RandomrandomTilePosX, RandomrandomTilePosY);

        // Check if the gridManager.tiles dictionary contains the random position
        if (gridManager.tiles.ContainsKey(tilePosition))
        {
            tile = gridManager.tiles[tilePosition];
            print(tile);
           
            Instantiate(DebugPowerUp, new Vector3(tilePosition.x, tilePosition.y, -3), Quaternion.identity);
        }
        else 
        {
            Debug.Log("GetTile Error: failed to get tile");
        }

    }

}
