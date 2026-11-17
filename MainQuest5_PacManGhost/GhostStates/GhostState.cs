using MGGameLibrary;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost.GhostStates
{
    public abstract class GhostState : IState
    {
        public Vector2 Target { get; protected set; }

        protected GhostState(Vector2 target)
        {
            Target = target;
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void OnUpdate(float seconds) { }
    }
}
