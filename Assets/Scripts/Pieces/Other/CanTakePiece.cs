using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanTakePiece : MonoBehaviour
{
    private GirdManager gridManager;

    //get last clicked object
    //called when click canTakeCirle
    //move to click pos
    //destory whatever is on that tile.
    // Start is called before the first frame update

    /*
    public void TakePiece(Vector3 pos, GameObject lastClicked)
    {
        lastClicked.transform.position = new Vector3(pos.x, pos.y, -3);
    }
    */

    private void Awake()
    {
        gridManager = FindObjectOfType<GirdManager>();

    }

    /*
    public void TakePiece(Vector3 pos, GameObject lastClicked)
    {
        // Move the piece to the CanTakeCircle position
        lastClicked.transform.position = new Vector3(pos.x, pos.y, -3);

        // Get the tile at the CanTakeCircle position
        Tile targetTile = gridManager.GetTileAtPosition(pos);

        // Destroy the piece on the target tile if it exists
        if (targetTile != null && targetTile.piece != null)
        {
            Destroy(targetTile.piece);
        }

        // Move the clicked piece onto the target tile
        targetTile.piece = lastClicked;
    }
    */
}
