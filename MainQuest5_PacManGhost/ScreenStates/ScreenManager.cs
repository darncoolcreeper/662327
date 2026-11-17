using MGGameLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost.ScreenStates
{
    public class ScreenManager : DrawableGameComponent
    {
        private FiniteStateMachine<ScreenState, IStateTransition> _fsm;

        private ScreenState _currentState;

        public ScreenManager(Game game) : base(game)
        {
            Texture2D lightBulb = Game.Content.Load<Texture2D>("lightBulb");
            //Texture2D logo = Game.Content.Load<Texture2D>("AjaniLink");
            SpriteFont font = Game.Content.Load<SpriteFont>("TitleText");

            FlashScreenState flashScreen = new(1, Game);
            TitleScreenState titleScreen = new(Game);
            CreditsScreenState creditsScreen = new(Game);
            GameScreenState gameScreen = new(Game);
            PauseScreenState pauseScreen = new(Game);
            GameOverScreenState gameOverScreen = new(2, gameScreen, Game);


            




            KeyPressTransition pressC = new(Keys.C);
            KeyPressTransition pressP = new(Keys.P);
            KeyPressTransition pressSpace = new(Keys.Space);

            TimedTransition timedFlashScreenTransition = new(flashScreen.Timer);
            TimedTransition timedGameOverScreenTransition = new(gameOverScreen.Timer);

            SparseGraph<ScreenState, IStateTransition> graph = new();

            graph.AddEdge(flashScreen, timedFlashScreenTransition, titleScreen);
            graph.AddEdge(titleScreen, pressC, creditsScreen);
            graph.AddEdge(creditsScreen, pressC, titleScreen);
            graph.AddEdge(titleScreen, pressSpace, gameScreen);
            graph.AddEdge(pauseScreen, pressP, gameScreen);
            graph.AddEdge(gameScreen, pressP, pauseScreen);
            graph.AddEdge(gameScreen, pressC, gameOverScreen);
            graph.AddEdge(gameOverScreen, timedGameOverScreenTransition, titleScreen);

            _fsm = new FiniteStateMachine<ScreenState, IStateTransition>(graph, flashScreen);
        }

        public override void Update(GameTime gameTime)
        {
            float seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _fsm.Update(seconds);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _fsm.CurrentState.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
