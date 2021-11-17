using System;
namespace Microsoft.Excel.Codility.Q2
{
    public class Solution
    {
        public string solution(string S)
        {
            //crate hist with item for each letter
            var hist = InitHistOfUppercaseChars();

            //fill hist with char from string S
            FillHistWithChars(S, hist);

            // get the largest char in S if there is any or return "NO"
            string result = LookForBiggestDup(hist);
            return result;
        }

        private string LookForBiggestDup(LetterTupleExsit[] hist)
        {
            var result = "NO";
            for (int i = hist.Length - 1; i >= 0; i--)
            {
                if (hist[i].Both())
                {
                    result = hist[i].Letter.ToString();
                    break;
                }
            }

            return result;
        }

        private void FillHistWithChars(string S, LetterTupleExsit[] hist)
        {
            foreach (var letter in S)
            {
                if (letter <= 'z' && letter >= 'a')
                {
                    var item = hist[(int)(letter - 'a')];
                    item.Lower = true;
                }

                if (letter <= 'Z' && letter >= 'A')
                {
                    var item = hist[(int)(letter - 'A')];
                    item.Upper = true;
                }
            }
        }

        private LetterTupleExsit[] InitHistOfUppercaseChars()
        {
            LetterTupleExsit[] hist = new LetterTupleExsit[(int)(('z' - 'a') + 1)];
            for (int i = 0; i < hist.Length; i++)
            {
                hist[i] = new LetterTupleExsit((char)((int)'A' + i));
            }

            return hist;
        }
    }
}
