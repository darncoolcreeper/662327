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

        public List<Disc> _discsList;

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
            _discsList = new List<Disc>();

            //_discsList.Add(new Disc(5, new Vector2(GraphicsDevice.Viewport.Width / 2, 0), this));


            //_obstaclesList.Add(new Obstacle(
            //new Circle(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), 30)));



            //_obstaclesList.Add(new Obstacle(
            //new Circle(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 4), 30)));

            //_obstaclesList.Add(new Obstacle(
            //new Circle(new Vector2(GraphicsDevice.Viewport.Width / 4, GraphicsDevice.Viewport.Height / 3), 40)));

            //_obstaclesList.Add(new Obstacle(
            //new Circle(new Vector2(GraphicsDevice.Viewport.Width * (0.75f), GraphicsDevice.Viewport.Height / 3), 40)));

            int h = GraphicsDevice.Viewport.Height / 2;

            _obstaclesList.Add(new Obstacle(
                new Circle(new Vector2(GraphicsDevice.Viewport.Width / 4, h), 40)));
            _obstaclesList.Add(new Obstacle(
                new Circle(new Vector2(GraphicsDevice.Viewport.Width * 3 / 4, h), 40)));

            _discsList.Add(new Disc(5, new Vector2(GraphicsDevice.Viewport.Width / 3, GraphicsDevice.Viewport.Height / 2), this));
            _discsList.Add(new Disc(5, new Vector2(GraphicsDevice.Viewport.Width * 2 / 3, GraphicsDevice.Viewport.Height / 2), this));

            _discsList[0].ApplyImpulse(new Vector2(100, 0), (float)TargetElapsedTime.TotalSeconds);
            _discsList[1].ApplyImpulse(new Vector2(-100, 0), (float)TargetElapsedTime.TotalSeconds);

            _sceneManager = new SceneManager();


            _sceneManager.ChangeScene(new FlashScene(this, 3.0f));


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
                case FlashScene flashScene:
                    flashScene.Update(gameTime);
                    if(flashScene.Finished)
                    {
                        _sceneManager.ChangeScene(new TitleScene("Aztec Deflect", this));
                    }
                    break;
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
                    for (int i = 0; i < _discsList.Count; ++i)
                    {
                        //_discsList[i].ApplyGravity();
                        _discsList[i].Update((float)TargetElapsedTime.TotalSeconds);

                        foreach (Obstacle obstacle in _obstaclesList)
                        {
                            Disc disc = _discsList[i];
                            if (obstacle.CollidesWith(disc, ref collisionNormal))
                            {
                                
                                disc.RevertToPreviousPosition();
                                Vector2 desiredVelocity = Vector2.Reflect(disc.Velocity, collisionNormal);
                                disc.ApplyImpulse(desiredVelocity - disc.Velocity, (float)TargetElapsedTime.TotalSeconds);
                            }
                        }
                    }
                    for (int i = 0; i < _discsList.Count; i++)
                    {
                        for (int j = i + 1; j < _discsList.Count; j++)
                        {
                            Circle c1 = (Circle)_discsList[i].Shape;
                            Circle c2 = (Circle)_discsList[j].Shape;

                            if (c1.Intersects(c2))
                            {
                                
                                Vector2 parallel1 = Vector2.Dot(_discsList[i].Velocity, collisionNormal) * collisionNormal;
                                Vector2 perpendicular1 = _discsList[i].Velocity - parallel1;
                                Vector2 parallel2 = Vector2.Dot(_discsList[j].Velocity, collisionNormal) * collisionNormal;
                                Vector2 perpendicular2 = _discsList[j].Velocity - parallel2;

                                _discsList[j].Velocity = perpendicular1 + parallel2;
                                _discsList[i].Velocity = perpendicular2 + parallel1;
                            }
                        }
                    }







                    RemoveOrbs();
                    base.Update(gameTime);






                    break;
            }
            
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
                    foreach (Disc disc in _discsList)
                    {
                        Circle circle = disc.Shape as Circle;
                        Rectangle r = new Rectangle((int)(disc.Position.X - circle.radius), (int)(circle.Centre.Y - circle.radius), (int)circle.radius * 2, (int)circle.radius * 2);

                        _spriteBatch.Draw(textures, r, new Rectangle(512, 0, 256, 256), Color.Red);
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
