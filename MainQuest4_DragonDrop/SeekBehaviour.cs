using MGGameLibrary;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest4_DragonDrop
{
    public class SeekBehaviour : SteeringBehaviour
    {
        public ITargetable _target;




        public SeekBehaviour(ITargetable target)
        {
            _target = target;
        }


        public override Vector2 CalculateSteeringForce(Agent agent)
        {
            Vector2 desiredVelocity = _target.TargetPosition - agent.Position;
            desiredVelocity.Normalize();
            desiredVelocity *= agent.MaxSpeed;
            return desiredVelocity - agent.Velocity;
        }



    }





}
