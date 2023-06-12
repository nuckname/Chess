using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPiece : MonoBehaviour
{
    //using locationOfTiles is back as its has all the squares in it.

    public GameObject moveableLocationCircle;
    private SpawningMoveableCircles spawningMoveableCircles;
    private ObjectClicker objectClicker;

    private PawnAttacking pawnAttacking;

    private void pawnMovement(bool allowedDoubleMove, Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles, int direction)
    {
        
        int moveDistance = allowedDoubleMove ? 2 : 1;
        for (int i = 1; i <= moveDistance; i++)
        {
            Vector2 targetPos = new Vector2(pos.x, pos.y + (direction * i));
            
            if (locationOfTiles.ContainsKey(targetPos))
            {
                //doesnt currently work.
                Vector3 targetPosition = locationOfTiles[targetPos].transform.position;
                Instantiate(moveableLocationCircle, new Vector3(targetPosition.x, targetPosition.y, -3), Quaternion.identity);
                spawningMoveableCircles = FindObjectOfType<SpawningMoveableCircles>();



                spawningMoveableCircles.isBlocking();

                if (spawningMoveableCircles.hasPieceBlocking)
                {
                    break;
                }

                //testing pawnAttacking

                //Instantiate(moveableLocationCircle, new Vector3(targetPosition.x - 1, targetPosition.y - 1, -3), Quaternion.identity);
                //Instantiate(moveableLocationCircle, new Vector3(targetPosition.x - 1, targetPosition.y - 1, -3), Quaternion.identity);
            }
        }
    }

    public void OnPieceClickPawn(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        objectClicker = FindObjectOfType<ObjectClicker>();
        pawnAttacking = FindObjectOfType<PawnAttacking>();

        ClearAllPawnTakeCircle();

        if (objectClicker.colorOfPieceClicked == "white")
        {
            if (pos.y == 1)
            {
                pawnMovement(true, pos, locationOfTiles, 1);
                pawnAttacking.pawnAttack(pos, locationOfTiles);
            }
            else
            {
                pawnMovement(false, pos, locationOfTiles, 1);
                pawnAttacking.pawnAttack(pos, locationOfTiles);
            }
        }

        else if (objectClicker.colorOfPieceClicked == "black")
        {
            if(pos.y == 6)
            {
                pawnMovement(true, pos, locationOfTiles, -1);
                pawnAttacking.pawnAttack(pos, locationOfTiles);
            }
            else
            {
                pawnMovement(false, pos, locationOfTiles, -1);
                pawnAttacking.pawnAttack(pos, locationOfTiles);
            }
        }
    }

    private void ClearAllPawnTakeCircle()
    {
        GameObject[] canPawnTakeCircle = GameObject.FindGameObjectsWithTag("CanPawnTakeCircle");

        if(canPawnTakeCircle != null)
        {
            foreach (GameObject gameObject in canPawnTakeCircle)
            {
                //Destroy(gameObject);
            }
        }
    }
}
