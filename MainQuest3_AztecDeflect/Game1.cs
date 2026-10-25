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

        

        public List<EnergyOrb> _orbsList;

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();







            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {

                EnergyOrb orb = _ship.FireEnergyOrb();
                if( orb != null)
                {
                    _orbsList.Add(orb);
                    Components.Add(orb);
                }
                
            }

            
            RemoveOrbs();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.Draw(textures, _ship._rectangle, shipRect, Color.White);

            foreach (EnergyOrb energyOrb in _orbsList)
            {
                _spriteBatch.Draw(textures, energyOrb.Rectangle, new Rectangle(512, 0, 256, 256), Color.OrangeRed);
            }


            _spriteBatch.End();

            base.Draw(gameTime);
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
