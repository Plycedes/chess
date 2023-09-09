using System.Xml;
using UnityEngine;
using UnityEngine.UIElements;

public class ChessPieceSelector : MonoBehaviour
{
    Vector2 clickPostion;
    string pieceName;    
    int x, y;    

    GameObject selectedPiece, tempTile, oldPiece;  
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPostion, Vector2.up);
            if(hit.collider!= null)
            {                
                selectedPiece = hit.collider.gameObject;
                if (selectedPiece == oldPiece)
                {
                    ChessBoardPlacementHandler.Instance.ClearHighlights();
                    oldPiece = null;
                }
                else
                {
                    pieceName = hit.collider.tag;
                    x = (int)hit.transform.position.x;
                    y = (int)hit.transform.position.y;                    

                    switch (pieceName)
                    {
                        case "Pawn":
                            pawnMoves(x, y);
                            oldPiece = selectedPiece;
                            break;

                        case "Rook":
                            rookMoves(x, y);
                            oldPiece = selectedPiece;
                            break;

                        case "Bishop":
                            bishopMoves(x, y);
                            oldPiece = selectedPiece;
                            break;

                        case "Knight":
                            knightMoves(x, y);
                            oldPiece = selectedPiece;
                            break;

                        case "Queen":
                            queenMoves(x, y);
                            oldPiece = selectedPiece;
                            break;

                        case "King":
                            kingMoves(x, y);
                            oldPiece = selectedPiece;
                            break;

                        default: break;
                    }
                }         
            }
        }        
    }  

    void knightMoves(int xpos, int ypos) {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        int[] Xmoves = { 2, 1, -1, -2, -2, -1, 1, 2 };
        int[] Ymoves = { 1, 2, 2, 1, -1, -2, -2, -1 };
        int xval = xpos;
        int yval = ypos;

        for(int i = 0; i < 8; i++)
        {
            xpos = xval;
            ypos = yval;
            xpos = xpos + Xmoves[i];
            ypos = ypos + Ymoves[i];
            tempTile = ChessBoardPlacementHandler.Instance.GetTile(ypos, xpos);
            if (tempTile != null && !MovementHelper.Instance.CheckAbove(tempTile))
            {
                ChessBoardPlacementHandler.Instance.Highlight(ypos, xpos);
            }
        }        
    }

    void pawnMoves(int xposition, int yposition)
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();        
        if(yposition == 1)
        {
            MovementHelper.Instance.moveFront(2, xposition, yposition);
        }
        else
        {
            MovementHelper.Instance.moveFront(1, xposition, yposition);
        }

    }    
    
    void rookMoves(int xposition, int yposition)
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        MovementHelper.Instance.moveFront(8, xposition, yposition);
        MovementHelper.Instance.moveBack(8, xposition, yposition);
        MovementHelper.Instance.moveRight(8, xposition, yposition);
        MovementHelper.Instance.moveLeft(8, xposition, yposition);
    }

    void bishopMoves(int xposition, int yposition)
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        MovementHelper.Instance.moveFirstQuadrant(8, xposition, yposition);
        MovementHelper.Instance.moveSecondQuadrant(8, xposition, yposition);
        MovementHelper.Instance.moveThirdQuadrant(8, xposition, yposition);
        MovementHelper.Instance.moveFourthQuadrant(8, xposition, yposition);
    }

    void queenMoves(int xposition, int yposition)
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();        
        MovementHelper.Instance.moveFront(8, xposition, yposition);
        MovementHelper.Instance.moveBack(8, xposition, yposition);
        MovementHelper.Instance.moveRight(8, xposition, yposition);
        MovementHelper.Instance.moveLeft(8, xposition, yposition);
        MovementHelper.Instance.moveFirstQuadrant(8, xposition, yposition);
        MovementHelper.Instance.moveSecondQuadrant(8, xposition, yposition);
        MovementHelper.Instance.moveThirdQuadrant(8, xposition, yposition);
        MovementHelper.Instance.moveFourthQuadrant(8, xposition, yposition);
    }

    void kingMoves(int xposition, int yposition)
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        MovementHelper.Instance.moveFront(1, xposition, yposition);
        MovementHelper.Instance.moveBack(1, xposition, yposition);
        MovementHelper.Instance.moveRight(1, xposition, yposition);
        MovementHelper.Instance.moveLeft(1, xposition, yposition);
        MovementHelper.Instance.moveFirstQuadrant(1, xposition, yposition);
        MovementHelper.Instance.moveSecondQuadrant(1, xposition, yposition);
        MovementHelper.Instance.moveThirdQuadrant(1, xposition, yposition);
        MovementHelper.Instance.moveFourthQuadrant(1, xposition, yposition);
    }
}
