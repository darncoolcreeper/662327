using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary
{
    public interface ICollidable
    {
        public Shapes.Shape Shape { get; }

        public bool CollidesWith(ICollidable other);
        
    }
}
