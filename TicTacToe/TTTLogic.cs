using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TTTLogic
    {
        public enum XO
        {
            X,
            O,
            Empty,
        }
        XO NextMove = XO.X;

        public enum boardfull
        {
            boardisfull,
            boardisnotfull,
        }
        public XO turn()
        {
            return NextMove;
        }

        XO[,] board = new XO[3, 3] {
            {XO.Empty, XO.Empty, XO.Empty },
            {XO.Empty, XO.Empty, XO.Empty },
            {XO.Empty, XO.Empty, XO.Empty },
        };

        public delegate void OnIllegalMove();

        OnIllegalMove myIllegalMoveHandler;
        public TTTLogic(OnIllegalMove fnOnIllegalMove)
        {
            myIllegalMoveHandler = fnOnIllegalMove;
        }

        public static bool IsValidRow(int y)
        {
            return y >= 0 && y <= 2;
        }
        public static bool IsValidCol(int x)
        {
            return x >= 0 && x <= 2;
        }

        public void placingpiece(int positionX, int positionY)
        {
            XO thispiece = turn();
            if(positionX <0)
            {
                myIllegalMoveHandler();
                return;
            }
            else if(positionY<0)
            {
                myIllegalMoveHandler();
                return;
            }
            else if(positionX > 2)
            {
                myIllegalMoveHandler();
                return;

            }
            else if(positionY > 2)
            {
                myIllegalMoveHandler();
                return;
            }
            else if(board[positionX, positionY] != XO.Empty)
            {
                myIllegalMoveHandler();
                return;
            }
            
            if(this.NextMove == XO.X)
            {
                this.NextMove = XO.O;
            }
            else if (this.NextMove == XO.O)
            {
                this.NextMove = XO.X;
            }
            board[positionX, positionY] = thispiece;
        }

        public XO Getpiece(int positionX, int positionY)
        {
            return board[positionX, positionY];
        }

        // detect when all the squares are full

        public boardfull Checkfull()
        {
           for(int i=0; i<board.GetLength(0); i++)
            {
                for(int j=0; j<board.GetLength(1); j++)
                {
                    if(board[i, j]==XO.Empty)
                    {
                        return boardfull.boardisnotfull;
                    }
                }
            }

            return boardfull.boardisfull;
        }

        public enum WhoWon
        {
            XWins,
            OWins,
            StillPlaying,
        }
        
        public WhoWon state()
        {
            for(int i=0; i<board.GetLength(0); i++)
            {
                bool rowEqual = true;
                XO firstInRow = board[i, 0];
                bool colEqual = true;
                XO firstINCol = board[0, i];
                for (int j=0; j<board.GetLength(1); j++)
                {
                    rowEqual = rowEqual && board[i, j] == firstInRow;
                    colEqual = colEqual && board[j, i] == firstINCol;
                }

                if(rowEqual == true)
                {
                    if(firstInRow == XO.X)
                    {
                        return WhoWon.XWins;
                    }
                    if (firstInRow == XO.O)
                    {
                        return WhoWon.OWins;
                    }
                }
                if(colEqual == true)
                {
                    if (firstINCol == XO.X)
                    {
                        return WhoWon.XWins;
                    }
                    if (firstINCol == XO.O)
                    {
                        return WhoWon.OWins;
                    }
                }


            }

            return WhoWon.StillPlaying;
        }
    }
}
