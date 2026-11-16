using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost
{
    public class GameOverScreenState : ScreenState
    {
        private GameScreenState _theGame;
        private Timer _timer;

        public GameOverScreenState(float time, GameScreenState theGame, Game game) : base(game)
        {
            _theGame = theGame;
            _timer = new Timer(time);
        }

        public override void OnEnter()
        {
            _timer.Start();
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate(float seconds)
        {
            _timer.Update(seconds);
        }

        public override void Draw(GameTime gameTime)
        {
        }
    }
}
