 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPreviousSelection : MonoBehaviour
{
    public void ClearPreviousClick(GameObject lastClicked, GameObject currentHighlightSquare)
    {
        if (lastClicked != null)
        {
            ClearObjectsWithTag("CanMoveCircle");
            ClearObjectsWithTag("CanPawnTakeCircle");
            ClearObjectsWithTag("CanTakeCircle");
        }

        if (currentHighlightSquare != null)
        {
            Destroy(currentHighlightSquare);

            currentHighlightSquare = null;
        }
    }

    //This has a performance issue as it has to search the whole hierarchy. 
    private void ClearObjectsWithTag(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject objects in objectsWithTag)
        {
            Destroy(objects);
        }
    }
}
