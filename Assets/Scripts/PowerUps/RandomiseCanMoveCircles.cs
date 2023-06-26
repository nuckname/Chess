using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseCanMoveCircles : MonoBehaviour
{
    private GirdManager gridManager;
    private Tile tile;

    private GameObject[] canMoveCircleInstances;
    private void Awake()
    {
        gridManager = FindObjectOfType<GirdManager>();
    }

    private void UsePowerUpRandomiseMoves()
    {
        canMoveCircleInstances = GameObject.FindGameObjectsWithTag("CanMoveCircle");
        int rndRange = Random.Range(0, canMoveCircleInstances.Length);

        System.Random rndPos = new System.Random();
        int RandomrandomTilePosX = rndPos.Next(0, gridManager.xHeight);
        int RandomrandomTilePosY = rndPos.Next(0, gridManager.yHeight);

        canMoveCircleInstances[rndRange].transform.position = new Vector3(RandomrandomTilePosX, RandomrandomTilePosY, -3);

    }
}
