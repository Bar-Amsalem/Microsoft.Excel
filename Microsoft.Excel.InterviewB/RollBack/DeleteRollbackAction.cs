using Microsoft.Excel.InterviewB.Shapes;
using System;

namespace Microsoft.Excel.InterviewB.RollBack
{
    public class DeleteRollbackAction : IRollbackAction
    {
        private readonly IShape shape;

        public DeleteRollbackAction(IShape shape)
        {
            this.shape = shape ?? throw new ArgumentNullException(nameof(shape));
        }
        public void Undo(Canvas canvas)
        {
            Logger.Log($"\nUndo DeleteRollbackAction with shape:\n{shape}");
            if (canvas.AllShapes.Contains(shape))
            {
                shape.ShapeChanging -= canvas.ShapeModify;
                canvas.AllShapes.Remove(shape);
            }
        }
    }





}
