using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary.Shapes
{
    public abstract class Shape
    {
        public Vector2 Position { get; set; }

        public Shape(Vector2 position)
        {
            Position = position;
        }

        public abstract bool IsInside(Point point);
    }
}
