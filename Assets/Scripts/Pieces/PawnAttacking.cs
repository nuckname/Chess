using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnAttacking : MonoBehaviour
{
    public GameObject isPawnAttacking;

    public void GeneratePawnAttackingCircles(Vector2 pos, int TargetOnePosX, int TargetOnePosY, int TargetTwoPosX, int TargetTwoPosY)
    {
        Vector2 targetPos = new Vector2(pos.x - TargetOnePosX, pos.y - TargetOnePosY);
        Vector2 targetPos1 = new Vector2(pos.x - TargetTwoPosX, pos.y - TargetTwoPosY);

        Instantiate(isPawnAttacking, new Vector3(targetPos.x, targetPos.y, -3), Quaternion.identity);
        Instantiate(isPawnAttacking, new Vector3(targetPos1.x, targetPos1.y, -3), Quaternion.identity);

    }
}
