using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetColorPosOnClick : MonoBehaviour
{
    private GameObject _GameObject;
    public string GetObjectTag(RaycastHit2D hit)
    {
        string tag;
        _GameObject = hit.collider.gameObject;

        if(_GameObject.tag.Contains("Black"))
        {
            tag = "black";
        }

        else if (_GameObject.tag.Contains("White"))
        {
            tag = "white";
        }

        //what about when the user clicks on a moveCircleSquare.
        else
        {
            tag = "error";
            print("GetColorPosOnClick error");
        }
        

        return tag;
    }
}
