using Microsoft.Excel.InterviewA.Rules;
using System.Collections.Generic;

namespace Microsoft.Excel.InterviewA
{
    public class SpellChecker
    {
        private readonly List<IRule> rules = new List<IRule>();

        public SpellChecker AddRule(IRule rule)
        {
            rules.Add(rule);
            return this;
        }

        public bool CheckPharse(string phrase)
        {
            foreach (var rule in rules)
            {
                if (rule.IsValid(phrase) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }


}
