using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost
{
    public class FlashScreenState : ScreenState
    {
        public Timer Timer { get; private set; }

        public FlashScreenState(float time, Game game)
            : base(game)
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
        }
    }
}
