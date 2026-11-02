using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary
{
    public class PhysicsObject : GameComponent
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
            _previousPosition = Position;
            // a = F/m
            Vector2 acceleration = _force / _mass;
            // v = v0 + at
            Velocity += acceleration * deltaTime;
            // s = s0 + vt
            Position += Velocity * deltaTime;
            // Reset force for next frame
            _force = Vector2.Zero;
        }

        public void RevertToPreviousPosition()
        {

        }
        public void ApplyGravity()
        {
            const float GRAVITY = 250f; // pixels per second squared
            _force += new Vector2(0, GRAVITY * _mass);
        }

        public void ApplyImpulse(Vector2 changeInVelocity, float deltaTime)
        {
            // F = m * dv / dt
            Vector2 force = _mass * changeInVelocity / deltaTime;
            ApplyForce(force);
        }
    }
}
