using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary.Shapes
{
    public class LineSegment : Shape
    {




        

        public Vector2 Start { get { return Position; } set { Position = value; } }
        public Vector2 End { get; set; }
        public LineSegment(Vector2 start, Vector2 end) : base(start)
        {
            End = end;
        }
        public override bool Intersects(Shape other)
        {
            throw new NotImplementedException();
        }

        public override bool Intersects(Shape other, ref Vector2 collisionNormal)
        {
            throw new NotImplementedException();
        }

        public override bool IntersectsCircle(Circle circle)
        {
            throw new NotImplementedException();
        }

        public override bool IntersectsCircle(Circle other, ref Vector2 collisionNormal)
        {
            throw new NotImplementedException();
        }

        public override bool IsInside(Point point)
        {
            throw new NotImplementedException();
        }
    }
}
