using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost.ScreenStates
{
    public class FlashScreenState : ScreenState
    {
        public Timer Timer { get; private set; }
        public SpriteBatch _spriteBatch => ((Game1)Game). _spriteBatch;
        public SpriteFont TitleText => ((Game1)Game).TitleText;
        public FlashScreenState(float time, Game game) : base(game)
        {
            Timer = new Timer(time);
        }

        public override void OnEnter()
        {
            Timer.Start();
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate(float seconds)
        {
            Timer.Update(seconds);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Ivory);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(TitleText, "Flash Screen", new Vector2(100, 100), Color.Black);
            _spriteBatch.End();
        }
    }
}
