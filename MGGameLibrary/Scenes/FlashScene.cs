using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary.Scenes
{
    public class FlashScene : Scene
    {
        private Texture2D _logoTexture;
        private SpriteFont _timerFont;

        private Rectangle _rectangle;
        private Rectangle _rectangle1;
        private Rectangle _rectangle2;
        private Rectangle _rectangle3;

        private float _timeRemaining;

        public bool Finished => _timeRemaining <= 0;

        public FlashScene(Game game, float duration) : base(game)
        {
            _timeRemaining = duration;

            _logoTexture = game.Content.Load<Texture2D>("logo");

            _timerFont = game.Content.Load<SpriteFont>("Timer");

            int rectangleWidth = _logoTexture.Width;
            int rectangleHeight = _logoTexture.Height;

            int rectangle1Width = _logoTexture.Width;
            int rectangle1Height = _logoTexture.Height;

            int x = (Game.GraphicsDevice.Viewport.Width / 2) - rectangleWidth;
            int y = (Game.GraphicsDevice.Viewport.Height / 2) - rectangleHeight;

            int x1 = (Game.GraphicsDevice.Viewport.Width / 2);
            int y1 = (Game.GraphicsDevice.Viewport.Height / 2);
            int x2 = (Game.GraphicsDevice.Viewport.Width / 2) - rectangle1Width;
            int y2 = (Game.GraphicsDevice.Viewport.Height / 2);

            int x3 = (Game.GraphicsDevice.Viewport.Width / 2);
            int y3 = (Game.GraphicsDevice.Viewport.Height / 2) - rectangle1Height;

            _rectangle = new Rectangle(x, y, rectangleWidth, rectangleHeight);
            _rectangle1 = new Rectangle(x1, y1, rectangle1Width, rectangle1Height);
            _rectangle2 = new Rectangle(x2, y2, rectangle1Width, rectangle1Height);
            _rectangle3 = new Rectangle(x3, y3, rectangle1Width, rectangle1Height);
        }

        public override void Update(GameTime gameTime)
        {
            _timeRemaining -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(_logoTexture, _rectangle, Color.White);
            spriteBatch.Draw(_logoTexture, _rectangle1, Color.White);
            spriteBatch.Draw(_logoTexture, _rectangle2, Color.White);
            spriteBatch.Draw(_logoTexture, _rectangle3, Color.White);

            Vector2 timerPosition =new Vector2(Game.GraphicsDevice.Viewport.Width - _timerFont.MeasureString(_timeRemaining.ToString("0.0")).X - 10, 10);

            spriteBatch.DrawString(_timerFont, _timeRemaining.ToString("0.0"), timerPosition, Color.Yellow);

            spriteBatch.End();
        }
    }
}
