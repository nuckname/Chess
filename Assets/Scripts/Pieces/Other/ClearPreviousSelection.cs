 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPreviousSelection : MonoBehaviour
{
    public void ClearPreviousClick(GameObject lastClicked, GameObject currentHighlightSquare)
    {
        if (lastClicked != null)
        {
            ClearAllCanMoveCircles();
        }

        if (currentHighlightSquare != null)
        {
            Destroy(currentHighlightSquare);
            //Destroy(highlightSquare);

            currentHighlightSquare = null;
        }
    }

    private void ClearAllCanMoveCircles()
    {
        GameObject[] canMoveCircles = GameObject.FindGameObjectsWithTag("CanMoveCircle");
        foreach (GameObject circle in canMoveCircles)
        {
            Destroy(circle);
        }
    }
}
