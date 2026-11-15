using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost
{
    public class LightBulbOffState : LightBulbState
    {
        public LightBulbOffState(Rectangle rectangle) : base(rectangle)
        {
        }

        public override void OnEnter()
        {
            // stuff that happens when bulb turns off
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate(float seconds)
        {
        }
    }
}
