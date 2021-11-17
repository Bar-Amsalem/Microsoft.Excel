using Microsoft.Excel.InterviewB.Shapes;

namespace Microsoft.Excel.InterviewB.RollBack
{
    public class ModifyRollbackAction : IRollbackAction
    {
        readonly IShape shape;
        private readonly string propName;
        private readonly object oldValue;

        public ModifyRollbackAction(IShape shape,string propName, object oldValue)
        {
            if (string.IsNullOrEmpty(propName))
            {
                throw new System.ArgumentException($"'{nameof(propName)}' cannot be null or empty.", nameof(propName));
            }

            this.shape = shape ?? throw new System.ArgumentNullException(nameof(shape));
            this.propName = propName;
            this.oldValue = oldValue ?? throw new System.ArgumentNullException(nameof(oldValue));
        }
        public void Undo(Canvas canvas)
        {
            Logger.Log($"\nUndo ModifyRollbackAction with shape:\n{shape}");
            shape.ShapeChanging -= canvas.ShapeModify;
            shape.GetType().GetProperty(propName).SetValue(shape, oldValue);
            shape.ShapeChanging += canvas.ShapeModify;
        }
    }





}
