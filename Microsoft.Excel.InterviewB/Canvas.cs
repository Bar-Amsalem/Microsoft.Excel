using Microsoft.Excel.InterviewB.RollBack;
using Microsoft.Excel.InterviewB.Shapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Excel.InterviewB
{
    public class Canvas : ICanvas
    {
        protected readonly Stack<IRollbackAction> undoActions = new();
        public HashSet<IShape> AllShapes { get; } = new();

        public IShape this[int shapeId] => AllShapes.Where(s => s.ID == shapeId).FirstOrDefault();

        public void AddShape(IShape shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));
            Logger.Log($"\nAddShape with shape:\n{shape}");

            //need to check at least one key first
            shape.ShapeChanging += ShapeModify;
            AllShapes.Add(shape);
            undoActions.Push(new DeleteRollbackAction(shape));
        }

        public void RemoveShape(IShape shape)
        {
            Logger.Log($"\nRemoveShape with shape:\n{shape}");
            if (AllShapes.Contains(shape))
            {
                shape.ShapeChanging -= ShapeModify;
                AllShapes.Remove(shape);
                undoActions.Push(new AddRollbackAction(shape));
            }
        }

        public void Undo()
        {
            if (undoActions.Count > 0)
            {
                var action = undoActions.Pop();
                action.Undo(this);
            }
        }

        public void ShapeModify(object sender, string propName)
        {
            if (sender is IShape shape)
            {
                var oldValue = shape.GetType().GetProperty(propName).GetValue(shape);
                undoActions.Push(new ModifyRollbackAction(shape, propName,oldValue));
            }
        }

        public IEnumerator<IShape> GetEnumerator() => AllShapes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => AllShapes.GetEnumerator();
    }





}
