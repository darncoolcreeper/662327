using MGGameLibrary;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost
{
    public abstract class LightBulbState : IState
    {
        public Rectangle SourceRectangle { get; protected set; }

        protected LightBulbState(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }

        public virtual void OnUpdate(float seconds)
        {
        }
    }
}
