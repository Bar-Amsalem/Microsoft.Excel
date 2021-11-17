using System;
using System.Text;
using System.Threading;

namespace Microsoft.Excel.Codility.Q3
{
    public class Solution
    {
        public int PrintDelayTime_mSec = 100;

        public int solution(string[] B)
        {
            var firstBoard = new CheckersBoard(B);
            CheckersBoard.NewStage += PrintStage;
            return firstBoard.GetMaxEat();
        }

        public void PrintStage(CheckersBoard checkers)
        {
            if (checkers is null || checkers.board is null)
                return;
            var board = checkers.board;
            var sb = new StringBuilder();
            var length = board.GetLength(0);
            sb.AppendLine($"Current steps = {checkers.MaxEat}");
            sb.AppendLine();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if ((i == checkers.JafferRow) && (j == checkers.JafferCol))
                        sb.Append("O");
                    else
                        sb.Append(board[i, j] == 1 ? "X" : ".");
                }
                sb.AppendLine();
            }

            
            Console.Clear();
            Console.WriteLine(sb);
            Thread.Sleep(PrintDelayTime_mSec);
        }
    }
}