using MGGameLibrary.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.InteropServices;


namespace MainQuest4_DragonDrop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Agent _agent;
        public Agent _agent2;

        public Texture2D dragons;
        public Texture2D coins;
        public Texture2D rock;


        public Coin _coin;

        private bool _dragged = false;
        private Vector2 _dragOffset;

        public Rock _rock;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            int h = GraphicsDevice.Viewport.Height;
            int w = GraphicsDevice.Viewport.Width;


            _coin = new Coin(new Circle(new Vector2(200, 200), 30), Rectangle.Empty);
            _agent = new Agent(new Vector2(100, 100), 0, new SeekBehaviour(_coin), this);
            _agent2 = new Agent(new Vector2(300, 300), 0, new SeekBehaviour(_agent), this);
            _rock = new Rock(new Circle(new Vector2(w / 2, h / 2), 32));
            Components.Add(_agent);
            Components.Add(_agent2);
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            dragons = Content.Load<Texture2D>("dragons");
            coins = Content.Load<Texture2D>("coins");
            rock = Content.Load<Texture2D>("rock");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();




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















            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            
            _spriteBatch.Draw(coins, _coin.Circle.Position, new Rectangle(30, 30, coins.Width / 4, coins.Height / 4), Color.White);
            _spriteBatch.Draw(dragons, _agent.Position, new Rectangle(0, 0, dragons.Width / 3, dragons.Height / 2), Color.White, _agent.Heading, new Vector2(dragons.Width / 6, dragons.Height / 4), 1.0f, SpriteEffects.None, 0f);
            _spriteBatch.Draw(dragons, _agent2.Position, new Rectangle(dragons.Width / 3, dragons.Height / 2, dragons.Width / 3, dragons.Height / 2), Color.White, _agent2.Heading, new Vector2(dragons.Width / 6, dragons.Height / 4), 1.0f, SpriteEffects.None, 0f);
            _spriteBatch.Draw(rock, _rock.circle.Position - new Vector2(rock.Width / 2, rock.Height / 2), Color.White);
            
            _spriteBatch.End();
            base.Draw(gameTime);

            
        }

        
    }
}
