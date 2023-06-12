using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnAttacking : MonoBehaviour
{
    public Collider2D[] collider;
    public GameObject canTakeCirle;
    public GameObject isPawnAttacking;
    //public GameObject[] isPawnAttackingCirles;
    private GameObject[] isPawnAttackingCirles = new GameObject[2];

    private GetColorPosOnClick getColorPosOnClick;

    public void pawnAttack(Vector2 pos, Dictionary<Vector2, Tile> locationOfTiles)
    {
        collider = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 1f);

        //GameObject[] isPawnAttackingCirles = new GameObject[2];

        //different for black and white.
        Vector2 targetPos = new Vector2(pos.x + 1, pos.y - 1);
        Vector2 targetPos1 = new Vector2(pos.x - 1, pos.y - 1);

        //isPawnAttackingCirles = GameObject.FindGameObjectsWithTag("CanPawnTakeCircle");

        /*
        if (isPawnAttackingCirles[0] != null)
        {
            Destroy(isPawnAttackingCirles[0]);
        }
        if (isPawnAttackingCirles[1] != null)
        {
            Destroy(isPawnAttackingCirles[1]);
        }
        */

        Instantiate(isPawnAttacking, new Vector3(targetPos.x, targetPos.y, -3), Quaternion.identity);
        Instantiate(isPawnAttacking, new Vector3(targetPos1.x, targetPos1.y, -3), Quaternion.identity);

        //Instantiate(isPawnAttacking, new Vector3(targetPos.x, targetPos.y, -3), Quaternion.identity);
        //Instantiate(isPawnAttacking, new Vector3(targetPos1.x, targetPos1.y, -3), Quaternion.identity);

    }
}
