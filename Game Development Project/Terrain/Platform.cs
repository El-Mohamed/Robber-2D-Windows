using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Development_Project
{
    class Platform : Block
    {
        public Platform(Texture2D texture, Vector2 position, Rectangle collisonRectangle) : base(texture, position, collisonRectangle)
        {
            ID = 1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture1, Position, Color.White);
        }
    }
}
