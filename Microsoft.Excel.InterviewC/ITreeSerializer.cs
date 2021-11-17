namespace Microsoft.Excel.InterviewC
{

        public interface ITreeSerializer
        {
            INode Deserialize(string txt);
            string Serialize(INode node);
        }

}

