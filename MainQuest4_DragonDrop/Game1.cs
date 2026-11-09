using MGGameLibrary.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MainQuest4_DragonDrop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Agent _agent;

        public Texture2D dragons;
        public Texture2D coins;
        public Coin _coin;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            _coin = new Coin(new Circle(new Vector2(200, 200), 20), Rectangle.Empty);
            _agent = new Agent(new Vector2(100, 100), 0, new SeekBehaviour(_coin), this);
            Components.Add(_agent);
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            dragons = Content.Load<Texture2D>("dragons");
            coins = Content.Load<Texture2D>("coins");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(dragons, _agent.Position, new Rectangle(0, 0, dragons.Width / 3, dragons.Height / 2), Color.White, _agent.Heading, new Vector2(dragons.Width / 6, dragons.Height / 4), 1.0f, SpriteEffects.None, 0f);

            _spriteBatch.Draw(coins, _coin.Circle.Position, new Rectangle(0, 0, coins.Width / 4, coins.Height / 4), Color.White, 0f, new Vector2(coins.Width / 8, coins.Height / 8), 1.0f, SpriteEffects.None, 0f);

            _spriteBatch.End();
            base.Draw(gameTime);

            
        }

        
    }
}
