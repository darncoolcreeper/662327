using MGGameLibrary;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost.GhostStates
{
    public class MoveToTargetState : IState
    {
        public Vector2 Target { get; }

        public MoveToTargetState(Vector2 target)
        {
            Target = target;
        }

        public void OnEnter() { }
        public void OnExit() { }
        public void OnUpdate(float seconds) { }
    }
}
