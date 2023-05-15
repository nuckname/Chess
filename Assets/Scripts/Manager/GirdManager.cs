using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirdManager : MonoBehaviour
{
    [SerializeField] private Tile tile;
    [SerializeField] private int xHeight;
    [SerializeField] private int yHeight;
    [SerializeField] private Transform cam;

    [SerializeField] private GameObject debugSqaure;

    public Dictionary<Vector2, Tile> tiles;

    //need to put into awake or public Dictionary<Vector2, Tile> tiles is null.
    private void Awake()
    {
        GenerateChessBoard();
    }

    void GenerateChessBoard()
    {
        tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < xHeight; x++)
        {
            for (int y = 0; y < yHeight; y++)
            {
                var spawnTile = Instantiate(tile, new Vector2(x, y),Quaternion.identity);
                spawnTile.name = $"Tile: {x},{y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnTile.Init(isOffset);

                tiles[new Vector2(x, y)] = spawnTile;
            }
        }
        cam.transform.position = new Vector3((float)yHeight / 2 - 0.5f, (float)xHeight / 2 - 0.5f, -10);
      

    }
}
