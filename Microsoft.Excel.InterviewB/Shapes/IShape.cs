using System;

namespace Microsoft.Excel.InterviewB.Shapes
{

    public interface IShape 
    {
        event EventHandler<string> ShapeChanging;
        int ID { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int Color { get; set; }
    }





}
