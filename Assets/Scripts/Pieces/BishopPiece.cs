using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopPiece : MonoBehaviour
{
    //Debug.Log(Mathf.Round(10.5f));
    private DirectionalInput directionalInput;
    public bool onCollisionDestroy = false;

    private void Awake()
    {
        directionalInput = FindObjectOfType<DirectionalInput>();
    }

    public void OnPieceClickBishop(Vector2 pos)
    {
        int[][] directions = new int[][] { new int[] { -1, -1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { 1, 1 } };

        directionalInput.drawingAttackLines(pos, directions);
    }
    /*

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(onCollisionDestroy)
        {
            Destroy(gameObject);
        }
    }
    */
}
