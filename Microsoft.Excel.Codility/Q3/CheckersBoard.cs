using System;

namespace Microsoft.Excel.Codility.Q3
{
    public class CheckersBoard
    {
        //0 = Empty
        //1 = black

        public static event NewStageDelegate NewStage;
        public readonly int[/*row*/,/*col*/] board;
        public int JafferRow { get; }
        public int JafferCol { get; }
        public int MaxEat { get; set; }
        public CheckersBoard(string[] B)
        {
            MaxEat = 0;
            board = new int[B.Length, B.Length];
            for (int iRow = 0; iRow < B.Length; iRow++)
            {
                var row = B[iRow];
                for (int iCol = 0; iCol < row.Length; iCol++)
                {
                    var ch = row[iCol];
                    if (ch == 'X')
                    {
                        board[iRow, iCol] = 1;
                    }
                    else if (ch == 'O')
                    {
                        JafferRow = iRow;
                        JafferCol = iCol;
                    }
                    else
                    {
                        board[iRow, iCol] = 0;
                    }

                }
            }
        }
        public CheckersBoard(int[/*row*/,/*col*/] board, int jafferRow, int jafferCol, int maxEat)
        {
            this.board = board ?? throw new ArgumentNullException(nameof(board));
            JafferRow = jafferRow;
            JafferCol = jafferCol;
            MaxEat = maxEat;
        }
        public bool CanEatRight()
        {
            //check of board limits
            if (JafferCol >= board.GetLength(0) - 2)
                return false; //top right limit

            if (JafferRow <= 1)
                return false; //top row limit

            //check for Aladin item
            if (board[JafferRow - 1, JafferCol + 1] == 0)
                return false; // No item

            if (board[JafferRow - 1, JafferCol + 1] == 1 && board[JafferRow - 2, JafferCol + 2] == 1)
                return false; // Item block by more then one tool

            //if reach here Jaffar can eat right
            return true;
        }

        public bool CanEatLeft()
        {
            //check of board limits
            if (JafferCol <= 1)
                return false; //top left limit

            if (JafferRow <= 1)
                return false; //top row limit

            //check for Aladin item
            if (board[JafferRow - 1, JafferCol - 1] == 0)
                return false; // No item

            if (board[JafferRow - 1, JafferCol - 1] == 1 && board[JafferRow - 2, JafferCol - 2] == 1)
                return false; // Item block by more then one tool

            //if reach here Jaffar can eat left
            return true;
        }

        public CheckersBoard EatRight()
        {
            return new CheckersBoard(board, JafferRow - 2, JafferCol + 2, MaxEat + 1);
        }

        public CheckersBoard EatLeft()
        {
            return new CheckersBoard(board, JafferRow - 2, JafferCol - 2, MaxEat + 1);
        }

        public int GetMaxEat()
        {
            var canEatRight = CanEatRight();
            var canEatLeft = CanEatLeft();
            int resRight = 0;
            int resLeft = 0;
            if (canEatRight)
            {
                NewStage?.Invoke(this);
                var right = EatRight();
                resRight = right.GetMaxEat();
            }
            if (canEatLeft)
            {
                NewStage?.Invoke(this);
                var left = EatLeft();
                resLeft = left.GetMaxEat();
            }
            NewStage?.Invoke(this);

            if (canEatRight || canEatLeft)
                return Math.Max(resRight, resLeft);
            return MaxEat;

        }
    }
}