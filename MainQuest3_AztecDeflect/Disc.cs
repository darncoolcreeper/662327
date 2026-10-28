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
    internal class Disc : PhysicsObject, ICollidable
    {
        public const int DISC_RADIUS = 5;

        public const int DISC_MASS = 5;

        public Circle _circle;
        //public Shape Shape;

        public Disc(float mass, Vector2 position, Game game) : base(mass, position, game)
        {

        }

        public Shape Shape => throw new NotImplementedException();

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
