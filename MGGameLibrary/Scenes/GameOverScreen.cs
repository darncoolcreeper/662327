using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary.Scenes
{
    public class GameOverScreen : Scene
    {


        private SpriteFont _titleTextFont;





        private int finalScore;

        public GameOverScreen(Game game, int score) : base(game)
        {
            finalScore = score;
            _titleTextFont = game.Content.Load<SpriteFont>("TitleText");

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {


            Game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            string finalScoreString = finalScore.ToString("0");
            string scoreText = $"Final Score: {finalScoreString}";
            spriteBatch.DrawString(_titleTextFont, "Game Over", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - _titleTextFont.MeasureString("Game Over").X / 2, Game.GraphicsDevice.Viewport.Height / 2 - _titleTextFont.MeasureString("Game Over").Y / 2), Color.Red);
            spriteBatch.DrawString(_titleTextFont, scoreText, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - _titleTextFont.MeasureString(scoreText).X / 2, Game.GraphicsDevice.Viewport.Height / 2 - _titleTextFont.MeasureString(scoreText).Y / 2 + 50), Color.Yellow);

            
            
            
            
            
            

            spriteBatch.End();

        }
    }
}
