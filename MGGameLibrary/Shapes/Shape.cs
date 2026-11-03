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

        public static bool Intersects(Circle c, Square s, ref Vector2 collisionNormal)
        {
            // Find the closest point on the square to the circle's center
            float closestX = Math.Clamp(c.Centre.X, s.Position.X, s.Position.X + s.size);
            float closestY = Math.Clamp(c.Centre.Y, s.Position.Y, s.Position.Y + s.size);
            Vector2 closestPoint = new Vector2(closestX, closestY);

            // Vector from closest point to circle center
            Vector2 diff = c.Centre - closestPoint;
            float distanceSquared = diff.LengthSquared();

            if (distanceSquared <= c.radius * c.radius)
            {
                collisionNormal = diff != Vector2.Zero ? Vector2.Normalize(diff) : Vector2.UnitY;
                return true;
            }
            collisionNormal = Vector2.Zero;
            return false;
        }
    }
}
