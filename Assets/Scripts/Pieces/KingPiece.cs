using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingPiece : MonoBehaviour
{
    private bool hasMoved;
    public GameObject moveableLocationCircle;
    private BlockingAndTaking blockingAndTaking;
    private GameObject tempMoveCircle;
    private ObjectClicker objectClicker;

    private DirectionalInput directionalInput;

    private GirdManager gridManager;
    private bool tileFound;

    private HasRookMoved hasRookMoved;

    
    private GameObject tempMoveableCircle;

    private CanCastle canCastle;

    private bool stopCheckingChecks = false;
    private void Awake()
    {
        gridManager = FindObjectOfType<GirdManager>();
        

        canCastle = FindObjectOfType<CanCastle>();
    }

    private void Start()
    {
        hasRookMoved = FindObjectOfType<HasRookMoved>();
    }

    public void OnPieceClickKing(Vector2 pos)
    {
        canCastle.KingPosition = pos;
        canCastle.Castling();

        int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { -1, -1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { 1, 1 } };

        foreach (int[] direction in directions)
        {
            int directionX = direction[0];
            int directionY = direction[1];

            Vector2 tilePosition = new Vector2(pos.x + directionX, pos.y + directionY);
            tileFound = gridManager.GetTileAtPosition(tilePosition);

            if (tileFound)
            {
                Instantiate(moveableLocationCircle, new Vector3(tilePosition.x, tilePosition.y, -3), Quaternion.identity);

                blockingAndTaking = FindObjectOfType<BlockingAndTaking>();
                blockingAndTaking.addColliderBoxes();
                blockingAndTaking.isBlocking();
            }
           
        }
    }



}
