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
    public class StroopShape
    {
        private Color _colour;
        private Rectangle _rectangle;
        private Texture2D _texture;

        public StroopShape(Rectangle rectangle, Color colour, Texture2D texture)
        {
            _rectangle = rectangle;
            _colour = colour;
            _texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, _colour);
        }

        public bool IsInside(Point point)
        {
            return _rectangle.Contains(point);
        }

        public override string ToString()
        {
            return $"{_colour} {_texture}";
        }
    }
}
