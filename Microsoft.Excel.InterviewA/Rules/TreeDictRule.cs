using System.Collections.Generic;

namespace Microsoft.Excel.InterviewA.Rules
{
    public class TreeDictRule : IRule
    {
        private readonly Node root = new Node();

        public bool IsValid(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
            {
                return true;
            }
            phrase = phrase.Trim();
            var node = root;
            foreach (var ch in phrase)
            {
                if (node.Children.TryGetValue(ch, out node) == false)
                    break;
            }
            return node != null && node.ValidEnd;
        }

        public TreeDictRule AddPhrases(params string[] phrases)
        {
            if (phrases != null)
            {
                foreach (var phrase in phrases)
                {
                    root.AddPhrase(phrase);
                }
            }
            return this;
        }

        private class Node
        {
            public Dictionary<char, Node> Children { get; } = new Dictionary<char, Node>();
            public bool ValidEnd { get; private set; }
            public Node AddPhrase(string phrase)
            {
                if (string.IsNullOrWhiteSpace(phrase) == false)
                {
                    AddPhrase(phrase.Trim().ToCharArray(), 0);
                }
                return this;
            }

            private void AddPhrase(char[] phrase, int offset)
            {
                if ((phrase == null) || (offset >= phrase.Length))
                {
                    return;
                }

                var currentChar = phrase[offset];
                if (Children.TryGetValue(currentChar, out var next) == false)
                    Children[currentChar] = next = new Node();

                if (phrase.Length - offset == 1)
                {
                    next.ValidEnd = true;
                }
                else
                {
                    next.AddPhrase(phrase, offset + 1);
                }
            }
        }
    }
}
