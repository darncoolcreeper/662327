using MGGameLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost.GhostStates
{
    public class Ghost
    {
        private FiniteStateMachine<GhostState, IStateTransition> _fsm;

        public Texture2D ghost;
        public Vector2 Position { get; private set; }

        public Ghost(Texture2D ghostTexture)
        {
            ghost = ghostTexture;
            //InCageState inCage =
            //    new InCageState(new Vector2(100, 100));

            //ChasingState chasing =
            //    new ChasingState(new Vector2(500, 100));

            //FleeingState fleeing =
            //    new FleeingState(new Vector2(100, 400));

            //EatenState eaten =
            //    new EatenState(new Vector2(500, 400));

            InCageState inCage = new(new Vector2(150, 125));

            ChasingState chasing =
                new(new Vector2(400, 125));

            FleeingState fleeing =
                new(new Vector2(150, 325));

            EatenState eaten =
                new(new Vector2(400, 325));

            SparseGraph<GhostState, IStateTransition> graph = new();

            graph.AddEdge(inCage,
                new KeyPressTransition(Keys.D1),
                chasing);

            graph.AddEdge(chasing,
                new KeyPressTransition(Keys.D2),
                fleeing);

            graph.AddEdge(fleeing,
                new KeyPressTransition(Keys.D3),
                eaten);

            graph.AddEdge(fleeing,
                new KeyPressTransition(Keys.D1),
                chasing);

            graph.AddEdge(eaten,
                new KeyPressTransition(Keys.D4),
                inCage);

            _fsm = new FiniteStateMachine<GhostState, IStateTransition>
            (
                graph,
                inCage
            );

            Position = inCage.Target;
        }

        public void Update(float seconds)
        {
            _fsm.Update(seconds);

            Vector2 target = _fsm.CurrentState.Target;

            Vector2 direction = target - Position;

            if (direction.Length() > 1)
            {
                direction.Normalize();
                Position += direction * 150f * seconds;
            }
        }

        public GhostState CurrentState
        {
            get { return _fsm.CurrentState; }
        }
    }
}
