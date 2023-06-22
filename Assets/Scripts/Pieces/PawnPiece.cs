using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPiece : MonoBehaviour
{
    //global variable?
    //using locationOfTiles is bad as its has all the squares in it.

    public GameObject moveableLocationCircle;
    private SpawningMoveableCircles spawningMoveableCircles;
    private ObjectClicker objectClicker;
    private PawnAttackingGameObject pawnAttackingGameObject;

    private PawnAttacking pawnAttacking;

    private void pawnMovement(bool allowedDoubleMove, Vector2 pos, int direction)
    {
        int moveDistance = allowedDoubleMove ? 2 : 1;
        for (int i = 1; i <= moveDistance; i++)
        {
            Vector2 targetPos = new Vector2(pos.x, pos.y + (direction * i));

            //currently no out of bounds check.
            Instantiate(moveableLocationCircle, new Vector3(targetPos.x, targetPos.y, -3), Quaternion.identity);
            spawningMoveableCircles = FindObjectOfType<SpawningMoveableCircles>();

            spawningMoveableCircles.isBlocking();

            if (spawningMoveableCircles.hasPieceBlocking)
            {
                break;
            }
        }
    }

    public void OnPieceClickPawn(Vector2 pos)
    {
        objectClicker = FindObjectOfType<ObjectClicker>();
        pawnAttacking = FindObjectOfType<PawnAttacking>();
        pawnAttackingGameObject = FindObjectOfType<PawnAttackingGameObject>();

        if (objectClicker.colorOfPieceClicked == "white")
        {
            if (pos.y == 1)
            {
                pawnMovement(true, pos, 1);
                pawnAttacking.GeneratePawnAttackingCircles(pos, 1, -1, -1 ,-1);
                
            }
            else
            {
                pawnMovement(false, pos, 1);
                pawnAttacking.GeneratePawnAttackingCircles(pos, 1, -1, -1, -1);
            }
        }

        else if (objectClicker.colorOfPieceClicked == "black")
        {
            if(pos.y == 6)
            {
                pawnMovement(true, pos, -1);
                pawnAttacking.GeneratePawnAttackingCircles(pos, - 1, 1, 1, 1);

            }
            else
            {
                pawnMovement(false, pos, -1);
                pawnAttacking.GeneratePawnAttackingCircles(pos, -1, 1, 1, 1);

            }
        }
    }
}
