using MGGameLibrary;
using MGGameLibrary.Shapes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest4_DragonDrop
{
    public class AvoidCollidableWithWhiskersBehaviour : SteeringBehaviour
    {
        private List<Vector2> _whiskers;
        private List<Rock> _rocks;
        private SeekBehaviour _seekBehaviour;

        public AvoidCollidableWithWhiskersBehaviour(List<Vector2> whiskers, List<Rock> rocks, ITargetable target)
        {
            _whiskers = whiskers;
            _rocks = rocks;
            _seekBehaviour = new SeekBehaviour(target);
        }

        public override Vector2 CalculateSteeringForce(Agent agent)
        {
            Vector2 force = _seekBehaviour.CalculateSteeringForce(agent);

            foreach (Rock rock in _rocks)
            {
                foreach (Vector2 whisker in _whiskers)
                {
                    Vector2 rotatedWhisker = Vector2.Transform(whisker, Matrix.CreateRotationZ(agent.Heading));

                    LineSegment line = new LineSegment(agent.Position, agent.Position + rotatedWhisker);

                    if(Shape.Intersects(line, rock.circle))
                    {
                        Vector2 avoid = agent.Position - rock.circle.Centre;

                        avoid.Normalize();
                        avoid *= agent.MaxSpeed;

                        force += avoid - agent.Velocity;
                    }
                }
            }

            return force;
        }
    }
}
