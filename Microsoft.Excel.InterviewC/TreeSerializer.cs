using System;
using System.Linq;
using System.Text;

namespace Microsoft.Excel.InterviewC
{
    public class TreeSerializer : ITreeSerializer
    {
        private static readonly char[] SpaicelChars = new char[] { '{', ',', '}' };
        public string Serialize(INode node)
        {
            StringBuilder sb = new StringBuilder();
            if (node != null)
                Serialize(node, sb);
            return sb.ToString();
        }
        private void Serialize(INode node, StringBuilder sb)
        {
            sb.Append(node.Value);
            if (node.Left != null || node.Right != null)
            {
                sb.Append("{");
                if (node.Left != null)
                    Serialize(node.Left, sb);


                if (node.Right != null)
                {
                    sb.Append(",");
                    Serialize(node.Right, sb);
                }
                sb.Append("}");
            }
        }


        public INode Deserialize(string txt)
        {
            var index = 0;
            return Deserialize(txt, ref index);

        }

        private INode Deserialize(string txt, ref int offset)
        {
            var node = new Node(int.Parse(txt.Skip(offset).TakeWhile(c => SpaicelChars.Contains(c) == false).ToArray()));
            for (; offset < txt.Length && SpaicelChars.Contains(txt[offset]) == false; offset++) ;

            if (txt[offset] == '{')
            {
                offset++;
                node.Left = GetChild(txt, ref offset);

                if (offset < txt.Length && txt[offset] == ',')
                {
                    offset++;
                    node.Right = GetChild(txt, ref offset);
                }

                offset++;
            }

            return node;

        }

        private INode GetChild(string txt, ref int offset)
        {
            int i = offset;
            INode child = null;
            for (; i < txt.Length; i++)
            {
                if (SpaicelChars.Contains(txt[offset]))
                {
                    offset = i;
                    break;
                }
                if (txt[i] >= '0' && txt[i] <= '9')
                {
                    child = Deserialize(txt, ref offset);
                    break;
                }
            }

            return child;
        }
    }
}

