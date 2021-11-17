using System.Collections.Generic;

namespace Microsoft.Excel.InterviewA.Rules
{
    public class InDictRule : IRule
    {
        private readonly HashSet<string> knownWords;
        public InDictRule(params string[] knowenWords)
        {
            knownWords = new HashSet<string>(knowenWords);
        }

        public InDictRule AddknownWords(params string[] words)
        {
            if (words is null)
                return this;

            foreach (var word in words)
            {
                if (string.IsNullOrWhiteSpace(word) == false)
                {
                    knownWords.Add(word);
                }
            }
            return this;
        }

        public bool IsValid(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return true;

            return knownWords.Contains(phrase.Trim());
        }



    }


}
