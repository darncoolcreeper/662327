using MGGameLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost
{
    public class LightBulb : GameComponent
    {
        public FiniteStateMachine<LightBulbState, IStateTransition> _fsm;
        public Rectangle SourceRectangle { get { return _fsm.CurrentState.SourceRectangle; } }

        public LightBulb(Game game) : base(game)
        {
            LightBulbOffState offState = new(new Rectangle(0, 0, 112, 150));
            LightBulbOnState onState = new(new Rectangle(112, 0, 112, 150));

            KeyPressTransition turnOnTransition = new(Keys.O);
            KeyReleaseTransition turnOffTransition = new(Keys.O);

            SparseGraph<LightBulbState, IStateTransition> graph = new();

            graph.AddNode(offState);
            graph.AddNode(onState);
            graph.AddEdge(offState, turnOnTransition, onState);
            graph.AddEdge(onState, turnOffTransition, offState);

            _fsm = new FiniteStateMachine<LightBulbState, IStateTransition>(graph, offState);
        }

        
        public override void Update(GameTime gameTime)
        {
            float seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _fsm.Update(seconds);
            base.Update(gameTime);
        }
    }
}
