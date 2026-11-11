using MGGameLibrary;
using MGGameLibrary.Scenes;
using MGGameLibrary.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace MainQuest4_DragonDrop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public SceneManager _sceneManager;

        public Agent _agent;
        public Agent _agent2;
        public Agent _agent3;
        public Agent _agent4;

        public Texture2D dragons;
        public Texture2D coins;
        public Texture2D rock;

        public AvoidCollidableWithWhiskersBehaviour avoidBehaviour;

        public Color _backgroundColour;
        public Coin _coin;

        private bool _dragged = false;
        private Vector2 _dragOffset;
        public int score = 0;
        public Rock _rock;

        public float _elapsedTime = 0f;
        public SpriteFont titleFont;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _sceneManager = new SceneManager();


            _sceneManager.ChangeScene(new FlashScene(this, 3.0f));
            int h = GraphicsDevice.Viewport.Height;
            int w = GraphicsDevice.Viewport.Width;
            List<Vector2> pathPoints = new List<Vector2>()
            {
                new Vector2(w / 2, 20), // top
                
                new Vector2(w - 20, h / 2), // right
                
                new Vector2(w / 2, h - 20), // bottom
               
                new Vector2(20, h / 2), // left
                
            };

            _coin = new Coin(new Circle(new Vector2(200, 200), 30), Rectangle.Empty);
            
            _agent3 = new Agent(new Vector2(w / 2, 20), 0, new PathFollowingBehaviour(pathPoints, 10f), this);

            
            _rock = new Rock(new Circle(new Vector2(w / 2, h / 2), 40));


            List<Vector2> whiskers = new List<Vector2>()
            {
                new Vector2(0, -100),
		        new Vector2(30, -100),
                new Vector2(-30, -100),
            };
            _agent = new Agent(new Vector2(100, 100), 0, new AvoidCollidableWithWhiskersBehaviour(whiskers, new List<Rock>() { _rock }, _coin), this);
            _agent2 = new Agent(new Vector2(300, 300), 0, new AvoidCollidableWithWhiskersBehaviour(whiskers, new List<Rock>() { _rock }, _agent), this);
            avoidBehaviour = new AvoidCollidableWithWhiskersBehaviour(whiskers, new List<Rock>() { _rock }, _agent2);
            _agent4 = new Agent(new Vector2(100, 400), 0, avoidBehaviour, this);


            Components.Add(_agent);
            Components.Add(_agent2);
            Components.Add(_agent3);
            Components.Add(_agent4);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            dragons = Content.Load<Texture2D>("dragons");
            coins = Content.Load<Texture2D>("coins");
            rock = Content.Load<Texture2D>("rock");
            titleFont = Content.Load<SpriteFont>("TitleText");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch(_sceneManager.CurrentScene)
            {
                case FlashScene flashScene:
                    flashScene.Update(gameTime);
                    //mouse down skips it
                    if (flashScene.Finished || Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        _sceneManager.ChangeScene(new TitleScene("Dragon Drop", this));
                    }
                    break;
                case TitleScene titleScene:
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        
                        _sceneManager.CurrentScene = null;

                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.C))
                    {
                        _sceneManager.ChangeScene(new CreditScene(this));
                    }
                    break;

                case CreditScene creditScene:
                    creditScene.Update(gameTime);
                    if (Keyboard.GetState().IsKeyDown(Keys.T))
                    {
                        _sceneManager.ChangeScene(new TitleScene("Dragon Drop", this));
                    }
                    break;
                case GameOverScreen gameOverScene:
                    gameOverScene.Update(gameTime);
                    if (Keyboard.GetState().IsKeyDown(Keys.R))
                    {
                        _sceneManager.ChangeScene(new TitleScene("Dragon Drop", this));
                        score = (int)_elapsedTime;
                    }
                    break;
                default:


                    _elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                    MouseState mouse = Mouse.GetState();


                    if (!_dragged && mouse.LeftButton == ButtonState.Pressed && _coin.Circle.IsInside(mouse.Position))
                    {
                        _dragged = true;
                        _dragOffset = _coin.Circle.Centre - mouse.Position.ToVector2();
                    }

                    if (_dragged)
                    {
                        _coin.MoveCoin(mouse.Position.ToVector2() + _dragOffset);
                    }

                    if (mouse.LeftButton == ButtonState.Released)
                    {
                        _dragged = false;
                    }



                    if ((Vector2.Distance(_agent.Position, _coin.Circle.Centre) <= 20 ||
                    Vector2.Distance(_agent2.Position, _coin.Circle.Centre) <= 20 ||
                    Vector2.Distance(_agent3.Position, _coin.Circle.Centre) <= 20 ||
                    Vector2.Distance(_agent4.Position, _coin.Circle.Centre) <= 20) && _elapsedTime > 2f)
                    {

                        _sceneManager.ChangeScene(new GameOverScreen(this, (int)_elapsedTime));
                        _elapsedTime = 0f;
                    }


                    LineSegment toCoin = new LineSegment(_agent.Position, _coin.Circle.Centre);

                    if (Shape.Intersects(toCoin, _rock.circle))
                    {
                        _backgroundColour = Color.SlateBlue;
                    }
                    else
                    {
                        _backgroundColour = Color.CornflowerBlue;
                    }


                    base.Update(gameTime);

                    break;
            }

            









            // TODO: Add your update logic here

            
        }

        
        protected override void Draw(GameTime gameTime)
        {
            switch(_sceneManager.CurrentScene)
            {
                case FlashScene flashScene:
                    flashScene.Draw(gameTime, _spriteBatch);
                    break;
                case TitleScene titleScene:
                    titleScene.Draw(gameTime, _spriteBatch);
                    break;
                case CreditScene creditScene:
                    creditScene.Draw(gameTime, _spriteBatch);
                    break;
                case GameOverScreen gameOverScene:
                    gameOverScene.Draw(gameTime, _spriteBatch);
                    break;
                default:
                    GraphicsDevice.Clear(_backgroundColour);

                    _spriteBatch.Begin();

                    _spriteBatch.Draw(coins, _coin.Circle.Position, new Rectangle(30, 30, coins.Width / 4, coins.Height / 4), Color.White);
                    _spriteBatch.Draw(dragons, _agent.Position, new Rectangle(0, 0, dragons.Width / 3, dragons.Height / 2), Color.White, _agent.Heading, new Vector2(dragons.Width / 6, dragons.Height / 4), 1.0f, SpriteEffects.None, 0f);
                    _spriteBatch.Draw(dragons, _agent2.Position, new Rectangle(dragons.Width / 3, dragons.Height / 2, dragons.Width / 3, dragons.Height / 2), Color.White, _agent2.Heading, new Vector2(dragons.Width / 6, dragons.Height / 4), 1.0f, SpriteEffects.None, 0f);
                    _spriteBatch.Draw(dragons, _agent3.Position, new Rectangle(2 * dragons.Width / 3, 0, dragons.Width / 3, dragons.Height / 2), Color.White, _agent3.Heading, new Vector2(dragons.Width / 6, dragons.Height / 4), 1.0f, SpriteEffects.None, 0f);
                    _spriteBatch.Draw(dragons, _agent4.Position, new Rectangle(2 * dragons.Width / 3, dragons.Height / 2, dragons.Width / 3, dragons.Height / 2), Color.White, _agent4.Heading, new Vector2(dragons.Width / 6, dragons.Height / 4), 1.0f, SpriteEffects.None, 0f);
                    _spriteBatch.Draw(rock, _rock.circle.Position - new Vector2(rock.Width / 2, rock.Height / 2), Color.White);
                    _spriteBatch.DrawString(titleFont, $"Time: {_elapsedTime:F2} ", new Vector2(10, 10), Color.White);

                    _spriteBatch.End();
                    base.Draw(gameTime);
                    break;
            }
            

            
        }

        
    }
}
