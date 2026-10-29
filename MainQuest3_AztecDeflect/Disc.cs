using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGGameLibrary;
using MGGameLibrary.Shapes;
using Microsoft.Xna.Framework;

namespace MainQuest3_AztecDeflect
{
    public class Disc : PhysicsObject, ICollidable
    {
        public const int DISC_RADIUS = 15;

        public const int DISC_MASS = 15;

        public Circle _circle;
        

        public Disc(float mass, Vector2 position, Game game) : base(mass, position, game)
        {
            Position = position;
            _circle = new Circle(Position, DISC_RADIUS);
        }

        public Shape Shape { get { return new Circle(Position, DISC_RADIUS); } }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            _circle.Position = Position;
            

        }
        public bool CollidesWith(ICollidable other)
        {
            throw new NotImplementedException();
        }

        public bool CollidesWith(ICollidable other, ref Vector2 collisionNormal)
        {
            throw new NotImplementedException();
        }
    }
}
