using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary.Scenes
{
    public class TitleScene : Scene
    {
        //SpriteFont _font;
        private SpriteFont _titleTextFont;

        public TitleScene(Game game)
            : base(game)
        {
            //_font = font;
            _titleTextFont = game.Content.Load<SpriteFont>("TitleText");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Game.GraphicsDevice.Clear(Color.Gainsboro);

            spriteBatch.Begin();

            string text = "Title Screen\nPress Space to Play";

            spriteBatch.DrawString(_titleTextFont, text, Vector2.Zero, Color.White);

            spriteBatch.End();

            Game.GraphicsDevice.Clear(Color.Gainsboro);
            spriteBatch.Begin();
            string titleText = "Title Screen\nPress Space to Play\nPress C to see the Credits";
            Vector2 titlePosition = new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - _titleTextFont.MeasureString(titleText).X / 2, Game.GraphicsDevice.Viewport.Height / 2 - _titleTextFont.MeasureString(titleText).Y / 2);

            spriteBatch.DrawString(_titleTextFont, titleText, titlePosition + new Vector2(2, 2), new Color(242f / 255, 70f / 255, 80f / 255, 1f));
            spriteBatch.DrawString(_titleTextFont, titleText, titlePosition, new Color(252f / 255, 234f / 255, 51f / 255, 1f));

            spriteBatch.End();
        }

        //public override void Update(GameTime gameTime)
        //{
        //    if (Keyboard.GetState().IsKeyDown(Keys.Space))
        //    {
        //        SceneManager.ChangeScene(new GameScene(Game));

        //    }
        //    if (Keyboard.GetState().IsKeyDown(Keys.C))
        //    {
        //        SceneManager.ChangeScene(new CreditsScene(Game));
        //    }
        //}
    }
}
