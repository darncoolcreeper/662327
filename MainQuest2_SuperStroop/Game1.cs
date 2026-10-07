using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MainQuest2_SuperStroop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Rectangle _circle;

        private Rectangle _triangle;

        private Rectangle _rectangle;

        private Rectangle _square;


        private Texture2D _circleTexture;

        private Texture2D _triangleTexture;

        private Texture2D _whitePixelTexture;

        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _circleTexture = Content.Load<Texture2D>("circle");
            _triangleTexture = Content.Load<Texture2D>("triangle");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            int x = 50;
            int y = 50;
            int rectangleWidth = 30;
            int rectangleHeight = 30;


            _circle = new Rectangle(x, y, rectangleWidth, rectangleHeight);
            _triangle = new Rectangle(x + 60, y, rectangleWidth, rectangleHeight);
            _rectangle = new Rectangle(x + 120, y, rectangleWidth * 2, rectangleHeight);
            _square = new Rectangle(x + 210, y, rectangleWidth, rectangleHeight);

            _whitePixelTexture = new Texture2D(GraphicsDevice, 1, 1);
            _whitePixelTexture.SetData(new Color[] { Color.White });

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
            _spriteBatch.Draw(_circleTexture, _circle, Color.Red);
            _spriteBatch.Draw(_triangleTexture, _triangle, Color.Yellow);
            _spriteBatch.Draw(_whitePixelTexture, _rectangle, Color.Blue);
            _spriteBatch.Draw(_whitePixelTexture, _square, Color.Green);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
