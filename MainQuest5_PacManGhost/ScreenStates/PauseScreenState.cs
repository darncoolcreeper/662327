using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost.ScreenStates
{
    public class PauseScreenState : ScreenState
    {
        public SpriteBatch _spriteBatch => ((Game1)Game)._spriteBatch;
        public SpriteFont TitleText => ((Game1)Game).TitleText;
        public PauseScreenState(Game game) : base(game)
        {
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

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MistyRose);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(TitleText, "Pause Screen", new Vector2(100, 100), Color.Black);
            _spriteBatch.End();
        }
    }
}
