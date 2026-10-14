using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest2_SuperStroop
{
    internal class StroopTriangle : StroopShape
    {
        public StroopTriangle(Game game, Color colour, Texture2D texture) : base(game, colour, texture)
        {
        }

        public override bool IsInside(Point point)
        {
            //triangle barycentric is inside method
            Vector2 p = new Vector2(point.X, point.Y);
            Vector2 a = new Vector2(_rectangle.X + _rectangle.Width / 2, _rectangle.Y);
            Vector2 b = new Vector2(_rectangle.X, _rectangle.Y + _rectangle.Height);
            Vector2 c = new Vector2(_rectangle.X + _rectangle.Width, _rectangle.Y + _rectangle.Height);
            return IsPointInTriangle(p, a, b, c);
        }

        private bool IsPointInTriangle(Vector2 p, Vector2 a, Vector2 b, Vector2 c)
        {
            Vector2 v0 = c - a;
            Vector2 v1 = b - a;
            Vector2 v2 = p - a;

            float dot00 = Vector2.Dot(v0, v0);
            float dot01 = Vector2.Dot(v0, v1);
            float dot02 = Vector2.Dot(v0, v2);
            float dot11 = Vector2.Dot(v1, v1);
            float dot12 = Vector2.Dot(v1, v2);

            float invDenom = 1 / (dot00 * dot11 - dot01 * dot01);
            float u = (dot11 * dot02 - dot01 * dot12) * invDenom;
            float v = (dot00 * dot12 - dot01 * dot02) * invDenom;

            return (u >= 0) && (v >= 0) && (u + v < 1);
        }
    }
}