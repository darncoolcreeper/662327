using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest2_SuperStroop
{
    internal class StroopSquare : StroopShape
    {
        public StroopSquare(Rectangle rectangle, Color colour, Texture2D texture) : base(rectangle, colour, texture)
        {
        }


        public override bool IsInside(Point point)
        {
            return _rectangle.Contains(point);
        }

        public override string ToString()
        {
            return $"{_colour} square";
        }
    }
}
