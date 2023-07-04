using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirdManager : MonoBehaviour
{
    //grid is spelt wrong.

    [SerializeField] private Tile tile;
    public int xHeight;
    public int yHeight;
    [SerializeField] private Transform cam;

    [SerializeField] private GameObject debugSqaure;

    public Dictionary<Vector2, Tile> tiles;
   
    public Tile GetTileAtPosition(Vector2 position)
    {
        if (tiles.ContainsKey(position))
        {
            return tiles[position];
        }
        return null;
    }

    //GenerateTiles.
    public void GenerateChessBoard()
    {
        tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < xHeight; x++)
        {
            for (int y = 0; y < yHeight; y++)
            {
                var spawnTile = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                spawnTile.name = $"Tile: {x},{y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnTile.Init(isOffset);

                tiles[new Vector2(x, y)] = spawnTile;

                // Adjust position based on tile size
                Vector3 tilePosition = new Vector3(x * tile.transform.localScale.x, y * tile.transform.localScale.y, 0);
                spawnTile.transform.position = tilePosition;
            }
        }

        // Adjust camera position based on the grid size
        float offsetX = (float)yHeight * tile.transform.localScale.x / 2 - 0.5f;
        float offsetY = (float)xHeight * tile.transform.localScale.y / 2 - 0.5f;
        cam.transform.position = new Vector3(offsetX, offsetY, -10);

        
    }
}
