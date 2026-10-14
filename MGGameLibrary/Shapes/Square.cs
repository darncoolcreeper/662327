using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary.Shapes
{
    internal class Square : Shape
    {
        protected float size;

        public Square(Vector2 position, float size) : base(position)
        {
            Position = position;
            this.size = size;
        }

        public override bool IsInside(Point point)
        {
            return point.X >= Position.X && point.X <= Position.X + size &&
                   point.Y >= Position.Y && point.Y <= Position.Y + size;
        }
    }
}
