using MGGameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost.ScreenStates
{
    public class GameOverTransition : IStateTransition
    {
        private GameScreenState _game;

        public GameOverTransition(GameScreenState game)
        {
            _game = game;
        }

        public bool ToTransition()
        {
            return !_game.Playing;
        }
    }
}
