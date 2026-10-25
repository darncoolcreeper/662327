using MGGameLibrary.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary
{
    public class Obstacle : ICollidable
    {
        private Shape _shape;

        public Shape Shape
        {
            get { return _shape; }
        }

        public Obstacle(Shape shape)
        {
            _shape = shape;
        }

        public bool CollidesWith(ICollidable other)
        {
            return _shape.Intersects(other.Shape);
        }
    }
}
