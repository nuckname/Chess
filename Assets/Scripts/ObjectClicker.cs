using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker: MonoBehaviour
{
    public RaycastHit2D hit;
    private SelectedPiece pieceMovement;
    
    private void Awake()
    {
        pieceMovement = FindObjectOfType<SelectedPiece>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                print("this is a hit: " + hit);

                pieceMovement.selectedPiece(hit);
            }
        }
    }
}

