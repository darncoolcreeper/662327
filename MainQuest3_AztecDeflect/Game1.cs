using MGGameLibrary;
using MGGameLibrary.Scenes;
using MGGameLibrary.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using static Microsoft.Xna.Framework.MathHelper;

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

        private float _discSpawnTimer = 0f;
        private Random _random = new Random();

        public int lives = 3;

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

            

            int h = GraphicsDevice.Viewport.Height / 2;
            int w = GraphicsDevice.Viewport.Width / 2;
            _obstaclesList.Add(new Obstacle(new Circle(new Vector2(150, h), 75)));
            _obstaclesList.Add(new Obstacle(new Circle(new Vector2(GraphicsDevice.Viewport.Width - 150, h), 75)));
            _obstaclesList.Add(new Obstacle(new Circle(new Vector2(w - 75, 75), 40)));
            _obstaclesList.Add(new Obstacle(new Circle(new Vector2(w + 75, 75), 40)));

            _obstaclesList.Add(new Obstacle(new Square(new Vector2(w - 100 / 2, h - 100 / 2), 100)));


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
                    //mouse down skips it
                    if(flashScene.Finished || Mouse.GetState().LeftButton == ButtonState.Pressed)
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
                    _discSpawnTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                    if (_discSpawnTimer <= 0)
                    {
                        float x = _random.Next(50, GraphicsDevice.Viewport.Width - 50);

                        Disc disc = new Disc(10, new Vector2(x, -100), this);

                        

                        _discsList.Add(disc);

                        _discSpawnTimer = 1.5f;
                    }
                    for (int i = _discsList.Count - 1; i >= 0; i--)
                    {
                        if (_discsList[i].Position.Y > GraphicsDevice.Viewport.Height)
                        {
                            Components.Remove(_discsList[i]);
                            lives--;

                            break;
                        }
                    }
                    for (int i = 0; i < _discsList.Count; ++i)
                    {
                        _discsList[i].ApplyGravity();
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
                    //bounce discs off each other
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
                    //bounce discs off orbs but acknowledges mass of discs and orbs, so the heavier disc will push the lighter orb away

                    for (int i = 0; i < _orbsList.Count; i++)
                    {
                        for (int j = 0; j < _discsList.Count; j++)
                        {
                            collisionNormal = Vector2.Zero;

                            if (_orbsList[i].CollidesWith(_discsList[j], ref collisionNormal))
                            {
                                _orbsList[i].RevertToPreviousPosition();

                                float m1 = _orbsList[i]._mass;
                                float m2 = _discsList[j]._mass;

                                Vector2 v1 = _orbsList[i].Velocity;
                                Vector2 v2 = _discsList[j].Velocity;

                                float vn1 = Vector2.Dot(v1, collisionNormal);
                                float vn2 = Vector2.Dot(v2, collisionNormal);

                                float newVn1 = (vn1 * (m1 - m2) + 2 * m2 * vn2) / (m1 + m2);

                                float newVn2 = (vn2 * (m2 - m1) + 2 * m1 * vn1) / (m1 + m2);

                                _orbsList[i].Velocity += (newVn1 - vn1) * collisionNormal;

                                _discsList[j].Velocity += (newVn2 - vn2) * collisionNormal;
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
                        else if (obstacle.Shape is Square square)
                        {
                            Rectangle r = new Rectangle((int)square.Position.X, (int)square.Position.Y, (int)square.size, (int)square.size);
                            _spriteBatch.Draw(textures, r, new Rectangle(256, 256, 256, 256), Color.White);
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
