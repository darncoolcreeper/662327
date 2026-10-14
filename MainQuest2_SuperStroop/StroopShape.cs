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
        private Vector2 _startPosition;
        private Vector2 _endPosition;
        private float _elapsedTime;
        private float _movementDuration;

        public StroopShape(Game game, Rectangle rectangle, Color colour, Texture2D texture) : base(game)
        {
            _colour = colour;
            _rectangle = rectangle;
            _texture = texture;
            _startPosition = new Vector2(rectangle.X, rectangle.Y);
            _endPosition = new Vector2(rectangle.X + Game.GraphicsDevice.Viewport.Width - 2 * rectangle.X, rectangle.Y);
            _elapsedTime = 0f;
            _movementDuration = 5f;
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
        public override void Update(GameTime gameTime)
        {
            _elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            float t = MathHelper.Clamp(_elapsedTime / _movementDuration, 0f, 1f);

            Vector2 newPosition = (1 - t) * _startPosition + t * _endPosition;
            _rectangle.X = (int)newPosition.X;
            _rectangle.Y = (int)newPosition.Y;

            base.Update(gameTime);
        }
    }
}
