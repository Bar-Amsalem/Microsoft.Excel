//Checkpoint.CloudGuerd.Codility
namespace Microsoft.Excel.Codility.Q2
{
    //contains POCO that store for each letter what if a lower case and upper case appered
    class LetterTupleExsit
    {
        public bool Upper { get; set; }
        public bool Lower { get; set; }

        public char Letter { get; }
        public LetterTupleExsit(char letter)
        {
            Letter = letter;
        }

        public bool Both()
        {
            return Upper && Lower;
        }
    }
}
