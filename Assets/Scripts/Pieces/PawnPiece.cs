using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPiece : MonoBehaviour
{
    public GameObject moveableLocationCircle;
    private BlockingAndTaking blockingAndTaking;
    private ObjectClicker objectClicker;
    private Ampersand ampersand;

    private PawnAttacking pawnAttacking;

    private void pawnMovement(bool allowedDoubleMove, Vector2 pos, int direction)
    {
        int moveDistance = allowedDoubleMove ? 2 : 1;
        for (int i = 1; i <= moveDistance; i++)
        {
            Vector2 targetPos = new Vector2(pos.x, pos.y + (direction * i));

            //currently no out of bounds check. Tiles.
             Instantiate(moveableLocationCircle, new Vector3(targetPos.x, targetPos.y, -3), Quaternion.identity);

            GameObject canMoveCircleScript = GameObject.FindWithTag("CanMoveCircle");
            print("found Object:" + canMoveCircleScript);
            //unnecessary if statement maybe. Test later.
            if (canMoveCircleScript != null)
            {
                blockingAndTaking = canMoveCircleScript.GetComponent<BlockingAndTaking>();
                pawnAttacking = canMoveCircleScript.GetComponent<PawnAttacking>();


                blockingAndTaking.addColliderBoxes();
                Collider2D[] colliders = blockingAndTaking.collider;

                blockingAndTaking.pawnFrontMoveCircleBlocking();
            }
        }
    }

    public void OnPieceClickPawn(Vector2 pos)
    {
        objectClicker = FindObjectOfType<ObjectClicker>();
        pawnAttacking = FindObjectOfType<PawnAttacking>();
        ampersand = FindObjectOfType<Ampersand>();

        if (objectClicker.colorOfPieceClicked == "white")
        {
            if (pos.y == 1)
            {
                //for ampersand spawn two pawnPieces on y 2 and y 3.
                //then remove when whites turn again.
                //same for black.
                pawnMovement(true, pos, 1);
                pawnAttacking.GeneratePawnAttackingCircles(pos, false);
                //needs to be on click.
                //ampersand.SpawnGameObjectBehindTile();
                
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
