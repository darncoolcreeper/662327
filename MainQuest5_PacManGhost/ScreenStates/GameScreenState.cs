using MainQuest5_PacManGhost.GhostStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost.ScreenStates
{
    public class GameScreenState : ScreenState
    {
        public bool Playing { get; set; }
        private Texture2D _pixel;
        public int Score { get; set; }

        private LightBulb _lightBulb;
        public SpriteBatch _spriteBatch => ((Game1)Game)._spriteBatch;
        private Ghost _ghost;
        private Texture2D ghostTexture;

        public GameScreenState(Game game) : base(game)
        {
            _lightBulb = new LightBulb(game);
            
            ghostTexture = Game.Content.Load<Texture2D>("Ghost");

            _ghost = new Ghost(ghostTexture);
            _pixel = new Texture2D(GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });
        }

        public override void OnEnter()
        {
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate(float seconds)
        {
            _ghost.Update(seconds);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Crimson);
            _spriteBatch.Begin();
            
            Rectangle cageRect = new(50, 50, 200, 150);
            Rectangle chaseRect = new(300, 50, 200, 150);
            Rectangle fleeRect = new(50, 250, 200, 150);
            Rectangle eatenRect = new(300, 250, 200, 150);
            _spriteBatch.Draw(_pixel, cageRect, Color.Blue);
            _spriteBatch.Draw(_pixel, chaseRect, Color.Green);
            _spriteBatch.Draw(_pixel, fleeRect, Color.Yellow);
            _spriteBatch.Draw(_pixel, eatenRect, Color.Red);


            //_spriteBatch.Draw(ghostTexture, _ghost.Position, Color.White);
            _spriteBatch.Draw(ghostTexture, _ghost.Position, null, Color.White, 0f, new Vector2(ghostTexture.Width / 2f, ghostTexture.Height / 2f), 0.2f, SpriteEffects.None, 0f);
            _spriteBatch.End();
        }
    }

}
