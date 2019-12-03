using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Development_Project
{
    class Door : Block
    {
        public Door(Texture2D texture, Vector2 position, Rectangle collisonRectangle) : base(texture, position, collisonRectangle)
        {
            ID = 2;
        }

       
    }
}
