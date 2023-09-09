using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHelper : MonoBehaviour
{
    bool canMoveInFront = true;
    GameObject tempTile;
    [SerializeField] private GameObject redTilePrefab;

    internal static MovementHelper Instance;

    private void Awake()
    {
        Instance = this;
    }

    internal bool CheckAbove(GameObject tile)
    {
        RaycastHit2D hit = Physics2D.Raycast(tile.transform.position, Vector3.forward);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Enemy")
            {                
                Instantiate(redTilePrefab, tile.transform.position, Quaternion.identity, tile.transform);
                //The rook near the queen is tagged enemy for demontration purpose.
            }
            return true;
        }
        else
        {
            return false;
        }
        

    }

    internal void moveFront(int maxMoves, int xpos, int ypos)
    {
        canMoveInFront = true;
        int count = 0;
        ypos += 1;
        tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
        while (tempTile != null && canMoveInFront && count < maxMoves)
        {
            if (CheckAbove(tempTile))
            {
                canMoveInFront = false;
            }
            else
            {
                ChessBoardPlacementHandler.Instance.Highlight(ypos, xpos);
                ypos += 1;
                count += 1;
                tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
            }
        }
    }

    internal void moveBack(int maxMoves, int xpos, int ypos)
    {
        canMoveInFront = true;
        int count = 0;
        ypos -= 1;
        tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
        while (tempTile != null && canMoveInFront && count < maxMoves)
        {
            if (CheckAbove(tempTile))
            {
                canMoveInFront = false;
            }
            else
            {
                ChessBoardPlacementHandler.Instance.Highlight(ypos, xpos);
                ypos -= 1;
                count += 1;
                tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
            }
        }
    }

    internal void moveRight(int maxMoves, int xpos, int ypos)
    {
        canMoveInFront = true;
        int count = 0;
        xpos += 1;
        tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
        while (tempTile != null && canMoveInFront && count < maxMoves)
        {
            if (CheckAbove(tempTile))
            {
                canMoveInFront = false;
            }
            else
            {
                ChessBoardPlacementHandler.Instance.Highlight(ypos, xpos);
                xpos += 1;
                count += 1;
                tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
            }
        }
    }

    internal void moveLeft(int maxMoves, int xpos, int ypos)
    {
        canMoveInFront = true;
        int count = 0;
        xpos -= 1;
        tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
        while (tempTile != null && canMoveInFront && count < maxMoves)
        {
            if (CheckAbove(tempTile))
            {
                canMoveInFront = false;
            }
            else
            {
                ChessBoardPlacementHandler.Instance.Highlight(ypos, xpos);
                xpos -= 1;
                count += 1;
                tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
            }
        }
    }

    internal void moveFirstQuadrant(int maxMoves, int xpos, int ypos)
    {
        canMoveInFront = true;
        int count = 0;
        xpos += 1;
        ypos += 1;
        tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
        while (tempTile != null && canMoveInFront && count < maxMoves)
        {
            if (CheckAbove(tempTile))
            {
                canMoveInFront = false;
            }
            else
            {
                ChessBoardPlacementHandler.Instance.Highlight(ypos, xpos);
                xpos += 1;
                ypos += 1;
                count += 1;
                tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
            }
        }
    }

    internal void moveSecondQuadrant(int maxMoves, int xpos, int ypos)
    {
        canMoveInFront = true;
        int count = 0;
        xpos -= 1;
        ypos += 1;
        tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
        while (tempTile != null && canMoveInFront && count < maxMoves)
        {
            if (CheckAbove(tempTile))
            {
                canMoveInFront = false;
            }
            else
            {
                ChessBoardPlacementHandler.Instance.Highlight(ypos, xpos);
                xpos -= 1;
                ypos += 1;
                count += 1;
                tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
            }
        }
    }

    internal void moveThirdQuadrant(int maxMoves, int xpos, int ypos)
    {
        canMoveInFront = true;
        int count = 0;
        xpos -= 1;
        ypos -= 1;
        tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
        while (tempTile != null && canMoveInFront && count < maxMoves)
        {
            if (CheckAbove(tempTile))
            {
                canMoveInFront = false;
            }
            else
            {
                ChessBoardPlacementHandler.Instance.Highlight(ypos, xpos);
                xpos -= 1;
                ypos -= 1;
                count += 1;
                tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
            }
        }
    }

    internal void moveFourthQuadrant(int maxMoves, int xpos, int ypos)
    {
        canMoveInFront = true;
        int count = 0;
        xpos += 1;
        ypos -= 1;
        tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
        while (tempTile != null && canMoveInFront && count < maxMoves)
        {
            if (CheckAbove(tempTile))
            {
                canMoveInFront = false;
            }
            else
            {
                ChessBoardPlacementHandler.Instance.Highlight(ypos, xpos);
                xpos += 1;
                ypos -= 1;
                count += 1;
                tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
            }
        }
    }
}
