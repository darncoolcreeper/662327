using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest2_SuperStroop
{
    internal class StroopCircle : StroopShape
    {
        public StroopCircle(Rectangle rectangle, Color colour, Texture2D texture) : base(rectangle, colour, texture)
        {
        }


        public override bool IsInside(Point point)
        {
            int radius = this._rectangle.Width / 2;
            Vector2 center = new Vector2(this._rectangle.X + this._rectangle.Width / 2, this._rectangle.Y + this._rectangle.Height / 2);
            float mouseDistance = (float)Math.Sqrt((Mouse.GetState().Y - center.Y) * (Mouse.GetState().Y - center.Y) + (Mouse.GetState().X - center.X) * (Mouse.GetState().X - center.X));



            return mouseDistance < radius;
        }
    }
}
