using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;



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

        private int lives = 3;
        private Texture2D _circleTexture;

        private Texture2D _triangleTexture;

        private Texture2D _whitePixelTexture;

        private StroopShape[] shapes;

        private SpriteFont _displayFont;
        private string _displayText = "Hello, Super Stroop!";
        private Color _displayColour = Color.White;

        private string requestText = "Please click on the shape that is the color requested";

        private ShapeRequester _shapeRequester;

        private Color[] colors;

        private Color requestColor;

        private MouseState mouseState;
        private MouseState prevMouseState;

        private StroopShape requestedShape;
        private int points = 0;
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
            _displayFont = Content.Load<SpriteFont>("Display");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _whitePixelTexture = new Texture2D(GraphicsDevice, 1, 1);
            _whitePixelTexture.SetData(new Color[] { Color.White });
            

            int x = 50;
            int y = 50;
            int rectangleWidth = 30;
            int rectangleHeight = 30;


            //_circle = new Rectangle(x, y, rectangleWidth, rectangleHeight);
            //_triangle = new Rectangle(x + 60, y, rectangleWidth, rectangleHeight);
            //_rectangle = new Rectangle(x + 120, y, rectangleWidth * 2, rectangleHeight);
            //_square = new Rectangle(x + 210, y, rectangleWidth, rectangleHeight);

            shapes = new StroopShape[]
            {
                new StroopCircle(new Rectangle(80, 70, 70, 70), Color.Red, _circleTexture),
                new StroopTriangle(new Rectangle(170, 70, 80, 80), Color.Green, _triangleTexture),
                new StroopSquare(new Rectangle(130, 170, 60, 60), Color.Blue, _whitePixelTexture),
            };

            colors = new Color[shapes.Length];
            for(int i = 0; i < shapes.Length; i++)
            {
                colors[i] = shapes[i].Colour;
            }



            _shapeRequester = new ShapeRequester(shapes, colors);


            requestedShape = _shapeRequester.RequestShape();
            requestColor = _shapeRequester.RequestColor();
            requestText = $"Click the {requestedShape.ToString()}";

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _displayText = "Mouse over nothing";
            foreach (StroopShape shape in shapes)
            {
                if (shape.IsInside(Mouse.GetState().Position))
                {
                    //make display color the shapes color
                    _displayColour = shape.Colour;
                    _displayText = $"Mouse over the {shape.ToString()}";
                }
            }

            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed &&
                prevMouseState.LeftButton == ButtonState.Released)
            {
                //if mouse is over the requested shape, update the requested shape and color
                if(requestedShape.IsInside(mouseState.Position))
                {
                    points += 100;
                    requestedShape = _shapeRequester.RequestShape();
                    requestColor = _shapeRequester.RequestColor();
                    requestText = requestedShape.ToString();
                }
                //if mouse is on a different shape, update the requested shape and color
                else if(shapes.Any(s => s.IsInside(mouseState.Position)))
                {
                    lives--;
                    requestedShape = _shapeRequester.RequestShape();
                    requestColor = _shapeRequester.RequestColor();
                    requestText = requestedShape.ToString();
                }

            }
            prevMouseState = mouseState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();




            //_spriteBatch.Draw(_circleTexture, _circle, Color.Red);
            //_spriteBatch.Draw(_triangleTexture, _triangle, Color.Yellow);
            //_spriteBatch.Draw(_whitePixelTexture, _rectangle, Color.Blue);
            //_spriteBatch.Draw(_whitePixelTexture, _square, Color.Green);

            for(int i = 0; i < shapes.Length; i++)
            {
                shapes[i].Draw(_spriteBatch);
            }
            Vector2 textPosition = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 - _displayFont.MeasureString(requestText).X / 2, 5);

            //_spriteBatch.DrawString(_displayFont, _displayText, new Vector2(textPosition.X +2, textPosition.Y + 2), Color.Black);

            //_spriteBatch.DrawString(_displayFont, _displayText, new Vector2(textPosition.X, textPosition.Y), _displayColour);
            _spriteBatch.DrawString(_displayFont, requestText, new Vector2(textPosition.X + 2, textPosition.Y + 2), Color.Black);

            _spriteBatch.DrawString(_displayFont, requestText, new Vector2(textPosition.X, textPosition.Y), requestColor);

            _spriteBatch.DrawString(_displayFont, $"Lives: {lives}", new Vector2(7, 7), Color.Black);
            _spriteBatch.DrawString(_displayFont, $"Lives: {lives}", new Vector2(5, 5), Color.White);

            _spriteBatch.DrawString(_displayFont, $"Points: {points}", new Vector2(_graphics.GraphicsDevice.Viewport.Width - _displayFont.MeasureString($"Points: {points}").X - 7, 7), Color.Black);
            _spriteBatch.DrawString(_displayFont, $"Points: {points}", new Vector2(_graphics.GraphicsDevice.Viewport.Width - _displayFont.MeasureString($"Points: {points}").X - 5, 5), Color.White);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
