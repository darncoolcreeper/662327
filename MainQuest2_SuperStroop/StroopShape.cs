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
    public abstract class StroopShape : GameComponent
    {
        protected Color _colour;

        public Color Colour => _colour;
        protected Rectangle _rectangle;
        private Texture2D _texture;

        public StroopShape(Game game, Rectangle rectangle, Color colour, Texture2D texture) : base(game)
        {
            _colour = colour;
            _rectangle = rectangle;
            _texture = texture;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, _colour);
        }

        public virtual bool IsInside(Point point)
        {
            return _rectangle.Contains(point);
        }

        public override string ToString()
        {
            return $"{_colour.ToColorName()} {_texture}";
        }
    }
}
