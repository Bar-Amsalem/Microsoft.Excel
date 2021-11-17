using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microsoft.Excel.InterviewB.Shapes
{
    public abstract class ShapeBase : IShape
    {
        protected int iD;
        protected int height;
        protected int width;
        protected int x;
        protected int y;
        protected int color;

        protected virtual void OnShapeChanging([CallerMemberName] string propertyName = null)
        {
            ShapeChanging?.Invoke(this, propertyName);
        }

        public event EventHandler<string> ShapeChanging;
        public virtual int ID
        {
            get => iD; set
            {
                OnShapeChanging();
                iD = value;
            }
        }
        public virtual int Height
        {
            get => height; set
            {
                OnShapeChanging();
                height = value;
            }
        }
        public virtual int Width
        {
            get => width; set
            {
                OnShapeChanging();
                width = value;
            }
        }
        public virtual int X
        {
            get => x; set
            {
                OnShapeChanging();
                x = value;
            }
        }
        public virtual int Y
        {
            get => y; set
            {
                OnShapeChanging();
                y = value;
            }
        }
        public virtual int Color
        {
            get => color; set
            {
                OnShapeChanging();
                color = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetType().Name);
            foreach (var p in GetType().GetProperties())
            {
                sb.AppendLine($"{p.Name}={p.GetValue(this)}");
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
