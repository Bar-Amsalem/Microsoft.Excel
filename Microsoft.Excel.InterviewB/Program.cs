using Microsoft.Excel.InterviewB.Shapes;
using System;

namespace Microsoft.Excel.InterviewB
{
    public class Program
    {
        /*
         * Requests:
         * 
         *  1. Instert Circle/Square
         *  2. Delete shapes
         *  3. Modify properties (size, position, color)
         *  4. Undo (endless)
         */
        public static void Main(string[] args)
        {
            ICanvas canvas = new Canvas();
            canvas.AddShape(new Square { ID = 1 });
            canvas.AddShape(new Circle { ID = 2 });
            canvas.AddShape(new Square { ID = 3 });
            canvas.AddShape(new Circle { ID = 4 });

            canvas[2].Height = 5;
            canvas[3].Color = 3;

            Logger.Log("Before undo");
            PrintCanvas(canvas);


            canvas.Undo();
            canvas.Undo();
            canvas.Undo();
            canvas.Undo();
            Logger.Log("\n\n\nAfter undo");
            PrintCanvas(canvas);
            Console.ReadKey();
        }
        private static void PrintCanvas(ICanvas canvas)
        {
            foreach (var shape in canvas)
            {
                Logger.Log($"{shape}\n");
            }
        }
    }


    public static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }





}
