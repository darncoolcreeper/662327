using MGGameLibrary.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest4_DragonDrop
{
    public class Coin
    {
        public Circle Circle;
        public Rectangle TextureSource;
        public Rectangle TextureRectangle;

        public Coin(Circle circle, Rectangle textureSource)
        {
            Circle = circle;
            TextureSource = textureSource;
            TextureRectangle = new Rectangle((int)(Circle.Position.X - Circle.radius), (int)(Circle.Position.Y - Circle.radius), (int)(Circle.radius * 2), (int)(Circle.radius * 2));
        }
    }
}
