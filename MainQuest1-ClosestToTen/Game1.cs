using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MainQuest1_ClosestToTen
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Rectangle _rectangle;
        private Rectangle _rectangle1;
        private Rectangle _rectangle2;
        private Rectangle _rectangle3;

        private Texture2D _whitePixelTexture;
        private Texture2D _redPixelTexture;

        private Texture2D _bluePixelTexture;

        private Texture2D _monogameLogoTexture;

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
            _monogameLogoTexture = Content.Load<Texture2D>("logo");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //int rectangleWidth = 200;
            //int rectangleHeight = 100;

            int rectangleWidth = _monogameLogoTexture.Width;
            int rectangleHeight = _monogameLogoTexture.Height;

            int rectangle1Width = _monogameLogoTexture.Width;
            int rectangle1Height = _monogameLogoTexture.Height;

            int x = (GraphicsDevice.Viewport.Width / 2) - rectangleWidth;
            int y = (GraphicsDevice.Viewport.Height / 2) - rectangleHeight;

            int x1 = (GraphicsDevice.Viewport.Width / 2);
            int y1 = (GraphicsDevice.Viewport.Height / 2);

            int x2 = (GraphicsDevice.Viewport.Width / 2) - rectangle1Width;
            int y2 = (GraphicsDevice.Viewport.Height / 2);

            int x3 = (GraphicsDevice.Viewport.Width / 2);
            int y3 = (GraphicsDevice.Viewport.Height / 2) -rectangle1Height;

            _rectangle = new Rectangle(x, y, rectangleWidth, rectangleHeight);
            _rectangle1 = new Rectangle(x1, y1, rectangle1Width, rectangle1Height);
            _rectangle2 = new Rectangle(x2, y2, rectangle1Width, rectangle1Height);
            _rectangle3 = new Rectangle(x3, y3, rectangle1Width, rectangle1Height);


            _whitePixelTexture = new Texture2D(GraphicsDevice, 1, 1);
            _whitePixelTexture.SetData(new Color[] { Color.White });

            _redPixelTexture = new Texture2D(GraphicsDevice, 1, 1);
            _redPixelTexture.SetData(new Color[] { Color.Red });

            _bluePixelTexture = new Texture2D(GraphicsDevice, 1, 1);
            _bluePixelTexture.SetData(new Color[] { Color.Blue });

            

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

            _spriteBatch.Draw(_monogameLogoTexture, _rectangle, Color.White);
            //_spriteBatch.Draw(_redPixelTexture, _rectangle, Color.White);
            _spriteBatch.Draw(_monogameLogoTexture, _rectangle1, Color.White);
            _spriteBatch.Draw(_monogameLogoTexture, _rectangle2, Color.White);
            _spriteBatch.Draw(_monogameLogoTexture, _rectangle3, Color.White);

            _spriteBatch.End();




            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
