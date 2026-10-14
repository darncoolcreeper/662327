using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest2_SuperStroop
{
    internal class ShapeRequester
    {
        public StroopShape[] shapes;
        public Color[] colors;
        public ShapeRequester(StroopShape[] shapes, Color[] colors)
        {
            this.shapes = shapes;
            this.colors = colors;
        }

        public StroopShape RequestShape()
        {
            Random random = new Random();
            int index = random.Next(shapes.Length);
            return shapes[index];
        }

        public Color RequestColor()
        {
            Random random = new Random();
            int index = random.Next(colors.Length);
            return colors[index];
        }

    }
}
