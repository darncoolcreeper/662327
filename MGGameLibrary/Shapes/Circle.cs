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
        public float radius;

        

        public Vector2 Centre => Position;

        public Circle(Vector2 position, float radius) : base(position)
        {
            Position = position;
            this.radius = radius;
        }
        


        public override bool IsInside(Point point)
        {
            Vector2 center = new Vector2(Position.X + radius / 2f, Position.Y + radius / 2f);

            float distance = Vector2.Distance(center, new Vector2(point.X, point.Y));

            return distance <= radius / 2f;
        }


        public override bool Intersects(Shape other)
        {
            return other.IntersectsCircle(this);
        }

        public override bool IntersectsCircle(Circle circle)
        {
            float distance = Vector2.Distance(Centre, circle.Centre);
            return distance <= radius + circle.radius;
        }

        public override bool Intersects(Shape other, ref Vector2 collisionNormal)
        {
            return other.IntersectsCircle(this, ref collisionNormal);
        }

        public override bool IntersectsCircle(Circle other, ref Vector2 collisionNormal)
        {
            //return Intersects(this, other, ref collisionNormal);
            bool collision = Vector2.Distance(Centre, other.Centre) <= radius + other.radius;

            
            if (collision)
            {
                collisionNormal = Vector2.Normalize(Centre - other.Centre);
            }

            return collision;
        }






    }
}
