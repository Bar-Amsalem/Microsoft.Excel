namespace Microsoft.Excel.InterviewC
{

        public interface ITreeSerializer
        {
            INode Deserialize(string txt);
            string Serialize(INode node);
        }

}
/*
2
>3
>>5
>>>7
>4
>>null
>>12


*/
