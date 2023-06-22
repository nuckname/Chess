using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookPiece : MonoBehaviour
{
    private DirectionalInput directionalInput;

    private void Awake()
    {
        directionalInput = FindObjectOfType<DirectionalInput>();
    }

    public void OnPieceClickRook(Vector2 pos)
    {
        int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };

        directionalInput.drawingAttackLines(pos, directions);
    }
}
