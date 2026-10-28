using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary
{
    internal class PhysicsObject : GameComponent
    {
        public float _mass;
        public Vector2 _position;

        public Vector2 _previousPosition;

        public Vector2 _velocity;

        public Vector2 _force;

        public Vector2 Position;

        public Vector2 Velocity;

        public PhysicsObject(float mass, Vector2 position, Game game) : base(game)
        {
            _mass = mass;
            _position = position;
        }

        public void ApplyForce(Vector2 force)
        {
            _force += force;
        }

        public virtual void Update(float deltaTime)
        {
            
        }

        public void RevertToPreviousPosition()
        {

        }
    }
}
