using Microsoft.Excel.InterviewA.Rules;
using System;

namespace Microsoft.Excel.InterviewA
{
    public class Program
    {
        public static void Main(string[] _)
        {
            var treeRule = new TreeDictRule().AddPhrases("hello world", "hello", "root");
            var dicRule = new InDictRule().AddknownWords("hello world", "hello", "root");

            var spellChecker = new SpellChecker()
                .AddRule(dicRule)
                //.AddRule(treeRule)
                ;

            var phrases = new string[]
            {
                "hello",
                "jhdbh",
                "hello world",
                "hellou",
                "h",
                "hello   ",
                " hello world ",
                "hello world today",
                null,
                "r",
                "root",
                "rooty",
            };

            foreach (var testCase in phrases)
            {
                var isOk = spellChecker.CheckPharse(testCase);
                var message = isOk ? $"Pass: {testCase}" : $"Fail: {testCase}";
                Console.WriteLine(message);
            }

            Console.ReadKey();

        }
    }


}
