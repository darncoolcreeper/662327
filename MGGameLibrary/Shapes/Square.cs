using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary.Shapes
{
    public class Square : Shape
    {
        protected float size;

        public Square(Vector2 position, float size) : base(position)
        {
            Position = position;
            this.size = size;
        }


        public override bool Intersects(Shape other)
        {
            

            if (other is Circle circle)
                return IntersectsCircle(circle);

            if (other is Square square)
            {
                return Position.X < square.Position.X + square.size &&
                       Position.X + size > square.Position.X &&
                       Position.Y < square.Position.Y + square.size &&
                       Position.Y + size > square.Position.Y;
            }

            return false;
        }

        public override bool Intersects(Shape other, ref Vector2 collisionNormal)
        {
            throw new NotImplementedException();
        }

        public override bool IntersectsCircle(Circle circle)
        {
            float closestX = MathHelper.Clamp(
            circle.Centre.X,
            Position.X,
            Position.X + size);

            float closestY = MathHelper.Clamp(
                circle.Centre.Y,
                Position.Y,
                Position.Y + size);

            float distanceX = circle.Centre.X - closestX;
            float distanceY = circle.Centre.Y - closestY;

            return distanceX * distanceX + distanceY * distanceY
                   <= circle.radius * circle.radius;
        }

        public override bool IntersectsCircle(Circle other, ref Vector2 collisionNormal)
        {
            throw new NotImplementedException();
        }

        public override bool IsInside(Point point)
        {
            
            return point.X >= Position.X && point.X <= Position.X + size &&
                   point.Y >= Position.Y && point.Y <= Position.Y + size;
        }
    }
}
