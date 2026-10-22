using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest3_AztecDeflect
{
    public class PlayerShip : GameComponent
    {
        public Rectangle _rectangle;

        public Rectangle Rectangle;

        public int shotsPerSecond = 10;
        public PlayerShip(Game game) : base(game)
        {
            _rectangle = new Rectangle(10, Game.GraphicsDevice.Viewport.Height - 10 - 75, 75, 75);
        }

        public void MoveSideways(int amount)
        {
            _rectangle.X += amount;
            if (_rectangle.X < 10) _rectangle.X = 10;
            if (_rectangle.X > Game.GraphicsDevice.Viewport.Width - 10 - _rectangle.Width) _rectangle.X = Game.GraphicsDevice.Viewport.Width - 10 - _rectangle.Width;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                MoveSideways(-5);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MoveSideways(5);
            }

            base.Update(gameTime);
        }

        public EnergyOrb FireEnergyOrb()
        {
            EnergyOrb orb = new EnergyOrb(new Vector2(_rectangle.Center.X, _rectangle.Center.Y - _rectangle.Height / 2), new Vector2(0, -200), Game);
            return orb;
        }
    }
    
}
