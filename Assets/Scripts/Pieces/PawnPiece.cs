using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private BlockingAndTaking blockingAndTakingPawn;
    private ObjectClicker objectClicker;

    private PawnAttacking pawnAttacking;

    private void pawnMovement(bool allowedDoubleMove, Vector2 pos, int direction)
    {
        int moveDistance = allowedDoubleMove ? 2 : 1;
        for (int i = 1; i <= moveDistance; i++)
        {
            Vector2 targetPos = new Vector2(pos.x, pos.y + (direction * i));

            //currently no out of bounds check.
            //currently collider has no array.
             Instantiate(moveableLocationCircle, new Vector3(targetPos.x, targetPos.y, -3), Quaternion.identity);
            //pawnMoveableCircles = FindObjectOfType<PawnMoveableCircles>();
            

            GameObject foundObject = GameObject.FindWithTag("CanMoveCircle");
            print("found Object:" + foundObject);
            if (foundObject != null)
            {
                blockingAndTakingPawn = foundObject.GetComponent<BlockingAndTaking>();
                pawnAttacking = foundObject.GetComponent<PawnAttacking>();

                //dont know if i need null checker.
                if (blockingAndTakingPawn != null)
                {
                    /*
                    if(spawningMoveableCircles.collider[0] != null)
                    {
                        print("very cool information: " + spawningMoveableCircles.collider[0]);

                    }
                    */
                }
            }
        }
    }

    private void blockingPawnAttackingInFrontOfPawn()
    {
        //if moveableLocationCircle hits enemy pawn.
    }

    public void OnPieceClickPawn(Vector2 pos)
    {
        objectClicker = FindObjectOfType<ObjectClicker>();
        //this scripot isnt oin the same GameOBject and is giving null error.
        //use tag to find script and then call .GeneratePawnAttackingCircles.
        pawnAttacking = FindObjectOfType<PawnAttacking>();
        //pawnAttackingGameObject = FindObjectOfType<PawnAttackingGameObject>();

        if (objectClicker.colorOfPieceClicked == "white")
        {
            if (pos.y == 1)
            {
                //for ampersand spawn two pawnPieces on y 2 and y 3.
                //then remove when whites turn again.
                //same for black.
                pawnMovement(true, pos, 1);
                pawnAttacking.GeneratePawnAttackingCircles(pos, false);
                
            }
            else
            {
                pawnMovement(false, pos, 1);
                pawnAttacking.GeneratePawnAttackingCircles(pos, false);
            }
        }

        else if (objectClicker.colorOfPieceClicked == "black")
        {
            if(pos.y == 6)
            {
                pawnMovement(true, pos, -1);
                pawnAttacking.GeneratePawnAttackingCircles(pos, true);
            }
            else
            {
                pawnMovement(false, pos, -1);
                pawnAttacking.GeneratePawnAttackingCircles(pos, true);
            }
        }
    }
}
