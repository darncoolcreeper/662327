using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGGameLibrary;

namespace MainQuest4_DragonDrop
{
    public class Agent : GameComponent
    {


        public PhysicsObject _physicsObject;

        public float Heading;

        public Vector2 Position { get { return _physicsObject.Position; } set { _physicsObject.Position = value; } }
        public Agent(Vector2 Position, float Heading, Game game) : base(game)
        {
            _physicsObject = new PhysicsObject(1, Position, game);
            this.Position = Position;
            this.Heading = Heading;
        }


        public override void Update(GameTime gameTime)
        {
            Heading += 0.01f;
            base.Update(gameTime);
        }




    }
}
