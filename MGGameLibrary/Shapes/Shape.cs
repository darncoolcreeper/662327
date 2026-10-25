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

        public abstract bool Intersects(Shape other);
        public abstract bool IntersectsCircle(Circle circle);

        public static bool Intersects(Circle c1, Circle c2)
        {
            float distance = Vector2.Distance(c1.Position, c2.Position);
            return distance < c1.radius + c2.radius;
        }

        public abstract bool Intersects(Shape other, ref Vector2 collisionNormal);
        public abstract bool IntersectsCircle(Circle other, ref Vector2 collisionNormal);
    }
}
