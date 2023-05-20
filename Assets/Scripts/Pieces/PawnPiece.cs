using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private IsBlockingPiece isBlockingPiece;
    private Collider2D[] _collider;
    private ObjectClicker objectClicker;

    //why are there two?
    public GameObject moveableLocationCirclePrefab;

    bool doubleMoveRule = true;

    public void OnPieceClickPawn(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        objectClicker = FindObjectOfType<ObjectClicker>();
        print("pawn" + objectClicker.colorOfPieceClicked);
        
        if(objectClicker.colorOfPieceClicked == "White")
        {

        }

        else if (objectClicker.colorOfPieceClicked == "Black")
        {

        }
        //have to check with tags
        //use color pos script.
        if (doubleMoveRule)
        {
            for(int i = 0; i <= 2; i++)
            {
                moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x, pos.y - i)].transform.position.x, locationOfTiles[new Vector2(pos.x, pos.y - i)].transform.position.y, -3), Quaternion.identity);
                doubleMoveRule = false;
            }
        }
        else
        {
            moveableLocationCirclePrefab = Instantiate(moveableLocationCircle, new Vector3(locationOfTiles[new Vector2(pos.x, pos.y + 1)].transform.position.x, locationOfTiles[new Vector2(pos.x, pos.y + 1)].transform.position.y, -3), Quaternion.identity);
        }

    }
}
