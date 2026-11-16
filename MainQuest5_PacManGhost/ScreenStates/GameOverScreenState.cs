using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost.ScreenStates
{
    public class GameOverScreenState : ScreenState
    {
        private GameScreenState _theGame;
        public Timer Timer { get; private set; }

        public GameOverScreenState(float time, GameScreenState theGame, Game game) : base(game)
        {
            _theGame = theGame;
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
            GraphicsDevice.Clear(Color.DeepPink);
        }
    }
}
