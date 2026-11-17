using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost.ScreenStates
{
    public class TitleScreenState : ScreenState
    {
        public SpriteBatch _spriteBatch => ((Game1)Game)._spriteBatch;
        public SpriteFont TitleText => ((Game1)Game).TitleText;
        public TitleScreenState(Game game) : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Teal);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(TitleText, "Title Screen", new Vector2(100, 100), Color.Black);
            _spriteBatch.End();
        }

        public override void OnEnter()
        {
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate(float seconds)
        {
        }
    }
}
