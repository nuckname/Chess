using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSize : MonoBehaviour
{
    private GirdManager grindManager;
    public void UsePowerUpChangeBoardSize()
    {

        grindManager = FindObjectOfType<GirdManager>();
        grindManager.yHeight = 10;
        grindManager.xHeight = 10;

        grindManager.GenerateChessBoard();
    }
}
