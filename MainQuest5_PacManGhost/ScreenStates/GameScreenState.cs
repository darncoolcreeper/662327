using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost
{
    public class GameScreenState : ScreenState
    {
        public bool Playing { get; set; }

        public int Score { get; set; }

        private LightBulb _lightBulb;

        public GameScreenState(Game game) : base(game)
        {
            _lightBulb = new LightBulb(game);
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
        }
    }

}
