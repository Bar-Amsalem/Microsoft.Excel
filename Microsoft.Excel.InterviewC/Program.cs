using Microsoft.Excel.InterviewC.LinkList;
using System;

namespace Microsoft.Excel.InterviewC
{
    partial class Program
    {
        private const string treeExpectedStr = "2{361{513{7}},400{,12}}";

        static void Main(string[] args)
        {
            var root = new Node(2)
            {
                Left = new Node(361)
                {
                    Left = new Node(513)
                    {
                        Left = new Node(7)
                    },
                },
                Right = new Node(400)
                {
                    Right = new Node(12)
                },
            };

            ITreeSerializer serializer = new TreeSerializer();

            var treeStr = serializer.Serialize(root);
            var strEqual = treeExpectedStr == treeStr;
            if (strEqual)
                Console.WriteLine("Serialized tree PASS");
            else
                Console.WriteLine("Serialized tree FAIL");


            var deserializedRoot = serializer.Deserialize(treeExpectedStr);

            var treesEquals = CompereTree(root, deserializedRoot);
            if (treesEquals)
                Console.WriteLine("Deserialize tree PASS");
            else
                Console.WriteLine("Deserialize tree FAIL");

            Console.WriteLine("\n\n\nLink list:");
            var l1 = new LinkedList().Add(5).Add(1).Add(2).Add(3).Add(4);
            var l2 = new LinkedList().Add(5).Add(6).Add(3).Add(4);
            var tail = ListAnalyzer.GetCommonTail(l1, l2);
            Console.WriteLine("For lists:");
            Console.WriteLine($"l1 :{l1}");
            Console.WriteLine($"l2 :{l2}");
            Console.WriteLine($"common tail :{tail}");

            l1 = new LinkedList().Add(1).Add(2).Add(3).Add(4);
            l2 = new LinkedList().Add(1).Add(2).Add(3).Add(5);
            tail = ListAnalyzer.GetCommonTail(l1, l2);
            Console.WriteLine("For lists:");
            Console.WriteLine($"l1 :{l1}");
            Console.WriteLine($"l2 :{l2}");
            Console.WriteLine($"common tail :{(tail == null ? "Nan" : tail.ToString())}");
            Console.ReadKey();
        }

        public static bool CompereTree(INode t1, INode t2)
        {
            if (t1 == t2) //null and same ref check
                return true;

            if (t1 == null || t2 == null) // only one null
                return false;

            return t1.Value == t2.Value && CompereTree(t1.Left, t2.Left) && CompereTree(t1.Right, t2.Right);

        }

    }
}

