using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary.Shapes
{
    public class Triangle : Shape
    {
        protected float size;

        public Triangle(Vector2 position, float size) : base(position)
        {
            Position = position;
            this.size = size;
        }

        public override bool Intersects(Shape other)
        {
            throw new NotImplementedException();
        }

        public override bool IntersectsCircle(Circle circle)
        {
            throw new NotImplementedException();
        }

        public override bool IsInside(Point point)
        {
            //calculate if is inside the triangle using barycentric coordinates
            Vector2 p = new Vector2(point.X, point.Y);
            //Vector2 a = new Vector2(Position.X, Position.Y);
            //Vector2 b = new Vector2(Position.X - size / 2, Position.Y + size);
            //Vector2 c = new Vector2(Position.X + size / 2, Position.Y + size);
            Vector2 a = new Vector2(Position.X + size / 2, Position.Y);
            Vector2 b = new Vector2(Position.X, Position.Y + size);
            Vector2 c = new Vector2(Position.X + size, Position.Y + size);

            float denominator = ((b.Y - c.Y) * (a.X - c.X) + (c.X - b.X) * (a.Y - c.Y));
            float alpha = ((b.Y - c.Y) * (p.X - c.X) + (c.X - b.X) * (p.Y - c.Y)) / denominator;
            float beta = ((c.Y - a.Y) * (p.X - c.X) + (a.X - c.X) * (p.Y - c.Y)) / denominator;
            float gamma = 1.0f - alpha - beta;

            return alpha >= 0 && beta >= 0 && gamma >= 0;
        }

    }
}
