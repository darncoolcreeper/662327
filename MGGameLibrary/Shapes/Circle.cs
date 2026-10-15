using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary.Shapes
{
    public class Circle : Shape
    {
        protected float radius;

        public Circle(Vector2 position, float radius) : base(position)
        {
            Position = position;
            this.radius = radius;
        }

        public override bool IsInside(Point point)
        {
            float distance = Vector2.Distance(Position, new Vector2(point.X, point.Y));
            return distance <= radius;

            



            
        }
    }
}
