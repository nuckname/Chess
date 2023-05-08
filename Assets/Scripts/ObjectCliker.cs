using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCliker : MonoBehaviour
{
    public GameObject lastClickedObject;
    public RaycastHit2D hit;
    //updates on sharing variable a good idea?
    private PieceMovement pieceMovement;
    
    private void Awake()
    {
        pieceMovement = FindObjectOfType<PieceMovement>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                pieceMovement.hello(hit);
            }
        }
    }
}

