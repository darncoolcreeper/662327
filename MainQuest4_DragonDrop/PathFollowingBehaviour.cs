using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest4_DragonDrop
{
    public class PathFollowingBehaviour : SteeringBehaviour
    {
        public List<Vector2> _pathPoints;
        public int _currentTargetIndex;
        public float _arrivalThreshold;
        public SeekBehaviour _seekBehaviour;

        public PathFollowingBehaviour(List<Vector2> pathPoints, float arrivalThreshold)
        {
            _pathPoints = pathPoints;
            _currentTargetIndex = 0;
            _arrivalThreshold = arrivalThreshold;
            
        }
        

        //public override Vector2 CalculateSteeringForce(Agent agent)
        //{
        //    float distanceToTarget = Vector2.DistanceSquared(agent.Position, _pathPoints[_currentTargetIndex].TargetPosition);
        //    if (distanceToTarget < _arrivalThreshold * _arrivalThreshold)
        //    {
        //        _currentTargetIndex++;

        //        if (_currentTargetIndex >= _pathPoints.Count)
        //        {
        //            _currentTargetIndex = 0; // Loop back to start
        //        }
        //        _seekBehaviour.TargetPosition = _pathPoints[_currentTargetIndex];
        //    }

        //    return _seekBehaviour.CalculateSteeringForce(agent);
        //}
        public override Vector2 CalculateSteeringForce(Agent agent)
        {
            Vector2 target = _pathPoints[_currentTargetIndex];

            if (Vector2.DistanceSquared(agent.Position, target) < _arrivalThreshold * _arrivalThreshold)
            {
                _currentTargetIndex++;

                if (_currentTargetIndex >= _pathPoints.Count)
                {
                    _currentTargetIndex = 0;
                }

                target = _pathPoints[_currentTargetIndex];
            }

            Vector2 desiredVelocity = target - agent.Position;

            if (desiredVelocity != Vector2.Zero)
            {
                desiredVelocity.Normalize();
            }

            return desiredVelocity * agent.MaxSpeed - agent.Velocity;
        }
    }
}
