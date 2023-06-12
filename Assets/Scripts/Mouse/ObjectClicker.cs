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
        getColorPosOnClick = FindObjectOfType<GetColorPosOnClick>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                //all of this be in a gamemanager?
                colorOfPieceClicked = getColorPosOnClick.GetObjectTag(hit);
                print("color clicked: " + colorOfPieceClicked);
                //should this be in a gameManager.
                //then call canTakemethod.
                pieceMovement.selectedPiece(hit);                                                                                                                                                                                                                                                                                           
            }
        }
    }
}

