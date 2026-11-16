using MGGameLibrary;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost.ScreenStates
{
    
    public abstract class ScreenState : DrawableGameComponent, IState
    {
        public ScreenState(Game game) : base(game)
        {
        }

        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void OnUpdate(float seconds);
        public abstract override void Draw(GameTime gameTime);
    }
}
