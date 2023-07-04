using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnAttacking : MonoBehaviour
{
    public GameObject isPawnAttacking;
    private bool isAttackingDown;

    public void GeneratePawnAttackingCircles(Vector2 pos, bool isAttackingDown)
    {
        //int moveDistance = allowedDoubleMove ? 2 : 1;

        int[] attackingPosition = isAttackingDown ? new int[] { -1, 1, 1, 1 } : new int[] { 1, -1, -1, -1 };

        //should sends out two canMoveCircles if it hits nothing delete thembut if it does hit something then turn them into canTakeCircles.
        Vector2 targetPos = new Vector2(pos.x - attackingPosition[0], pos.y - attackingPosition[1]);
        Vector2 targetPos1 = new Vector2(pos.x - attackingPosition[2], pos.y - attackingPosition[3]);

        Instantiate(isPawnAttacking, new Vector3(targetPos.x, targetPos.y, -3), Quaternion.identity);
        Instantiate(isPawnAttacking, new Vector3(targetPos1.x, targetPos1.y, -3), Quaternion.identity);

    }
}
