using System;
using System.IO;
using System.Linq;

namespace Microsoft.Excel.Codility
{
    public class Progam
    {
        public static void Main()
        {
            Q2();
            System.Threading.Thread.Sleep(1000);
            Q3();
            Console.ReadKey();
        }

        private static void Q2()
        {
            var testCases = new (string input, string output)[]
            {
                ("AaBbCcDd","D"),
                ("AaBbCcDD","C"),
                ("abcdefg","NO"),
                ("gfedcbaABF","F"),
            };
            var sln = new Q2.Solution();

            foreach (var (input, output) in testCases)
            {
                var result = sln.solution(input);
                if (result == output)
                {
                    Console.WriteLine($"PASS: {result}");
                }
                else
                {
                    Console.WriteLine($"FAIL: Expected:[{output}], Actual:[{result}]");
                }
            }


        }

        private static void Q3()
        {
            #region Code Testcase
            // string[] B = new string[10];
            // B[0] = "..........";
            // B[1] = "..........";
            // B[2] = ".....X.X..";
            // B[3] = "..........";
            // B[4] = "...X.X.X..";
            // B[5] = "..........";
            // B[6] = ".....X.X..";
            // B[7] = "..........";
            // B[8] = ".......X..";
            // B[9] = "........O.";
            #endregion
            var scenarios = File.ReadAllText("Q3_intput_txt.txt").Split("--END--", StringSplitOptions.RemoveEmptyEntries);

            var sln = new Q3.Solution();
            foreach (var test in scenarios)
            {
                var scenario = test.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                var expected = int.Parse(scenario[0]);
                var actual = sln.solution(scenario.Skip(1).ToArray());
                if (expected == actual)
                {
                    Console.WriteLine($"PASS: Maximum steps = {actual}");
                }
                else
                {
                    Console.WriteLine($"Fail: Expected Maximum steps = {expected}, Actual Maximum steps = {actual},");
                }
                System.Threading.Thread.Sleep(1000);
            }

        }
    }

}