using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker: MonoBehaviour
{
    public RaycastHit2D hit;
    private SelectedPiece pieceMovement;
    private GetColorPosOnClick getColorPosOnClick;
    public string colorOfPieceClicked;

    private void Awake()
    {
        pieceMovement = FindObjectOfType<SelectedPiece>();
        //This might not work as we are getting the Object to early.
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                getColorPosOnClick = FindObjectOfType<GetColorPosOnClick>();
                //make string hello public?
                string colorOfPieceClicked = getColorPosOnClick.GetObjectTag(hit);
                print(colorOfPieceClicked);

                pieceMovement.selectedPiece(hit);
                
                
            }
        }
    }
}

