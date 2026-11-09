using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest4_DragonDrop
{
    public abstract class SteeringBehaviour
    {
        public abstract Vector2 CalculateSteeringForce(Agent agent);
    }
}
