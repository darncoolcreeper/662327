using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary.Scenes
{
    public class SceneManager
    {
        public Scene CurrentScene { get; set; }

        public void ChangeScene(Scene scene)
        {
            CurrentScene = scene;
        }

        public void Update(GameTime gameTime)
        {
            CurrentScene?.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            CurrentScene?.Draw(gameTime, spriteBatch);
        }
    }
}
