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
    public class Agent : GameComponent, ITargetable
    {

        public SteeringBehaviour _behaviour;
        public PhysicsObject _physicsObject;

        public float Heading;

        public Vector2 TargetPosition => Position;
        public Vector2 Position { get { return _physicsObject.Position; } set { _physicsObject.Position = value; } }

        public Vector2 Velocity { get { return _physicsObject.Velocity; } set { _physicsObject.Velocity = value; } }

        public float MaxSpeed;
        public Agent(Vector2 Position, float Heading, SteeringBehaviour behaviour, Game game) : base(game)
        {
            _physicsObject = new PhysicsObject(1, Position, game);
            this.Position = Position;
            this.Heading = Heading;
            MaxSpeed = 100f;
            _behaviour = behaviour;
        }

        public void AlignHeadingToVelocity()
        {
            if (Velocity.LengthSquared() > 0)
            {
                Heading = (float)Math.Atan2(Velocity.Y, Velocity.X);
            }
        }
        public override void Update(GameTime gameTime)
        {
            // calculate steering force and apply to physics object
            Vector2 steeringForce = _behaviour.CalculateSteeringForce(this);
            _physicsObject.ApplyForce(steeringForce);
            _physicsObject.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            // align heading to velocity of physics object
            Vector2 velocity = _physicsObject.Velocity;
            if (velocity.LengthSquared() > 0)
            {
                velocity = Vector2.Normalize(velocity);
                Heading = MathF.Atan2(velocity.Y, velocity.X) + MathF.PI / 2;
            }

            base.Update(gameTime);
        }




    }
}
