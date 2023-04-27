using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCliker : MonoBehaviour
{
    public GameObject highlightSquare;
    private GameObject currentHighlightSquare;

    public GameObject moveableLocationCircle;
    public GameObject takeLocationSquare;

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null)
            {
                Vector3 pos = hit.collider.transform.position;

                if(currentHighlightSquare != null)
                {
                    Destroy(currentHighlightSquare);
                    currentHighlightSquare = null;
                }


                //snap zone?
                //if it hits anything.
                //Draw everwhere it can go
                //if it hits an object replace circle with square
                //make the hitbox for the cricle the full square of the board.
                //square can take
                //only allowed to move on cricle or sqaure.
                if(hit.collider.gameObject)
                {
                    currentHighlightSquare = Instantiate(highlightSquare, new Vector3(pos.x, pos.y, -3), Quaternion.identity);
                }

                if(hit.collider.gameObject.tag == "Knight")
                {
                    //up right ^^
                    Instantiate(moveableLocationCircle, new Vector3(pos.x + -1.1f, pos.y + -2.5f, -3), Quaternion.identity);
                    //up left ^^
                    Instantiate(moveableLocationCircle, new Vector3(pos.x + 4, pos.y + 3, -3), Quaternion.identity);
                    //down right vv
                    Instantiate(moveableLocationCircle, new Vector3(pos.x + 4, pos.y + 3, -3), Quaternion.identity);
                    //down left vv
                    Instantiate(moveableLocationCircle, new Vector3(pos.x + 4, pos.y + 3, -3), Quaternion.identity);
                }

                if (hit.collider.gameObject.tag == "Bishop")
                {

                }

            }
            else
            {
                if (currentHighlightSquare != null)
                {
                    Destroy(currentHighlightSquare);
                    currentHighlightSquare = null;
                }
            }
        }
    }
}

