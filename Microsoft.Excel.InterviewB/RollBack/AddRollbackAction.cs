using Microsoft.Excel.InterviewB.Shapes;

namespace Microsoft.Excel.InterviewB.RollBack
{
    public class AddRollbackAction : IRollbackAction
    {
        readonly IShape shape;
        public AddRollbackAction(IShape shape)
        {
            this.shape = shape ?? throw new System.ArgumentNullException(nameof(shape));
        }
        public void Undo(Canvas canvas)
        {
            Logger.Log($"\nUndo AddRollbackAction with shape:\n{shape}");
            shape.ShapeChanging += canvas.ShapeModify;
            canvas.AllShapes.Add(shape);
        }
    }





}
