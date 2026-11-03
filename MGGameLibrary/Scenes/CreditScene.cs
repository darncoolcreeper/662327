using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary.Scenes
{
    public class CreditScene : Scene
    {


        private SpriteFont _titleTextFont;





        public CreditScene(Game game) : base(game)
        {

            _titleTextFont = game.Content.Load<SpriteFont>("TitleText");

        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            

            Game.GraphicsDevice.Clear(Color.Goldenrod);
            spriteBatch.Begin();
            string creditsText = "Credits:\nMade by Isaac";
            spriteBatch.DrawString(_titleTextFont, creditsText, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - _titleTextFont.MeasureString(creditsText).X / 2, 10), Color.Black);
            spriteBatch.DrawString(_titleTextFont, "Press T to return to the Title Screen", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - _titleTextFont.MeasureString("Press T to return to the Title Screen").X / 2, Game.GraphicsDevice.Viewport.Height - 50), Color.Black);

            spriteBatch.End();

            
        }
    }
}
