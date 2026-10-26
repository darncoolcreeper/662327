using MGGameLibrary;
using MGGameLibrary.Scenes;
using MGGameLibrary.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MainQuest3_AztecDeflect
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private PlayerShip _ship;

        private Texture2D textures;

        private Rectangle shipRect = new Rectangle(0, 0, 256, 256);

        public SceneManager _sceneManager;

        public List<EnergyOrb> _orbsList;
        public List<ICollidable> _obstaclesList;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _ship = new PlayerShip(this);
            Components.Add(_ship);

            _orbsList = new List<EnergyOrb>();
            _obstaclesList = new List<ICollidable>();

            _obstaclesList.Add(new Obstacle(
            new Circle(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), 30)));
            //more obstacles


            _obstaclesList.Add(new Obstacle(
            new Circle(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 4), 30)));

            _obstaclesList.Add(new Obstacle(
            new Circle(new Vector2(GraphicsDevice.Viewport.Width / 4, GraphicsDevice.Viewport.Height / 3), 40)));

            _obstaclesList.Add(new Obstacle(
            new Circle(new Vector2(GraphicsDevice.Viewport.Width * (0.75f), GraphicsDevice.Viewport.Height / 3), 40)));

            _sceneManager = new SceneManager();

            _sceneManager.ChangeScene(new TitleScene(this));


            base.Initialize();
        }

        protected override void LoadContent()
        {
            textures = Content.Load<Texture2D>("textures");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            switch(_sceneManager.CurrentScene)
            {
                case TitleScene titleScene:
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        //case is default scene, so we can change to the game scene
                        //destroy title scene and change to game scene
                        _sceneManager.CurrentScene = null;

                    }
                    //if (Keyboard.GetState().IsKeyDown(Keys.C))
                    //{
                    //    _screen = Screen.CreditsScreen;
                    //}
                    break;
                default:

                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                        Exit();







                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {

                        EnergyOrb orb = _ship.FireEnergyOrb();
                        if (orb != null)
                        {
                            _orbsList.Add(orb);
                            Components.Add(orb);
                        }

                    }
                    //for (int i = 0; i < _orbsList.Count; ++i)
                    //{
                    //    foreach (Obstacle obstacle in _obstaclesList)
                    //    {
                    //        if (obstacle.CollidesWith(_orbsList[i]))
                    //        {
                    //            _orbsList[i].Velocity = Vector2.Zero;
                    //        }
                    //    }
                    //}

                    Vector2 collisionNormal = Vector2.Zero;
                    for (int i = 0; i < _orbsList.Count; ++i)
                    {
                        foreach (Obstacle obstacle in _obstaclesList)
                        {
                            if (obstacle.CollidesWith(_orbsList[i], ref collisionNormal))
                            {
                                _orbsList[i].RevertToPreviousPosition();
                                _orbsList[i].Velocity = Vector2.Reflect(_orbsList[i].Velocity, collisionNormal);
                            }
                        }
                    }
                    //_sceneManager.Update(gameTime);
                    RemoveOrbs();
                    base.Update(gameTime);






                    break;
            }
            
        }

        protected override void Draw(GameTime gameTime)
        {
            
            switch(_sceneManager.CurrentScene)
            {
                case TitleScene titleScene:
                    titleScene.Draw(gameTime, _spriteBatch);
                    break;
                default:

                    GraphicsDevice.Clear(Color.CornflowerBlue);

                    // TODO: Add your drawing code here

                    _spriteBatch.Begin();
                    _spriteBatch.Draw(textures, _ship._rectangle, shipRect, Color.White);

                    foreach (EnergyOrb energyOrb in _orbsList)
                    {
                        _spriteBatch.Draw(textures, energyOrb.Rectangle, new Rectangle(512, 0, 256, 256), Color.OrangeRed);
                    }
                    foreach (ICollidable obstacle in _obstaclesList)
                    {
                        if (obstacle.Shape is Circle circle)
                        {
                            Rectangle r = new Rectangle((int)(circle.Centre.X - circle.radius), (int)(circle.Centre.Y - circle.radius), (int)circle.radius * 2, (int)circle.radius * 2);

                            _spriteBatch.Draw(textures, r, new Rectangle(256, 0, 256, 256), Color.White);
                        }
                    }

                    _spriteBatch.End();

                    base.Draw(gameTime);



                    break;
            }
            
        }

        private void RemoveOrbs()
        {
            
            for (int i = _orbsList.Count - 1; i >= 0; --i)
            {
                if (_orbsList[i].Position.X < 0 ||
                    _orbsList[i].Position.X > GraphicsDevice.Viewport.Width ||
                    _orbsList[i].Position.Y < 0 ||
                    _orbsList[i].Position.Y > GraphicsDevice.Viewport.Height)
                {
                    Components.Remove(_orbsList[i]);
                    _orbsList.Remove(_orbsList[i]);
                }
            }

        }
    }
}
