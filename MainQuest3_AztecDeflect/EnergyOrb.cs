using MGGameLibrary;
using MGGameLibrary.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest3_AztecDeflect
{
    public class EnergyOrb : PhysicsObject, ICollidable
    {
        const int ORB_RADIUS = 5;
        //public Vector2 Position;
        //public Vector2 Velocity;
        //public Vector2 _previousPosition;
        public const int ORB_MASS = 5;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)(Position.X - ORB_RADIUS), (int)(Position.Y - ORB_RADIUS), ORB_RADIUS * 2, ORB_RADIUS * 2);
            }
        }

        
        public EnergyOrb(Vector2 position, Vector2 velocity, Game game) : base(ORB_MASS, position, game)
        {
            this.Position = position;
            this.Velocity = velocity;
        }
        public Shape Shape { get { return new Circle(Position, ORB_RADIUS); } } // yuck, inefficient

        public bool CollidesWith(ICollidable other)
        {
            return Shape.Intersects(other.Shape);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update((float)gameTime.ElapsedGameTime.TotalSeconds);


        }
        public bool CollidesWith(ICollidable other, ref Vector2 collisionNormal)
        {
            return Shape.Intersects(other.Shape, ref collisionNormal);
        }

        public void RevertToPreviousPosition()
        {
            Position = _previousPosition;
        }
    }
}
