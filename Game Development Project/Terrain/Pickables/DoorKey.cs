using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Development_Project
{
    class DoorKey : Block
    {
        public bool IsRightKey { get; set; }

        public DoorKey(Texture2D texture, Vector2 position, Rectangle collisionRectangle) : base(texture, position, collisionRectangle)
        {
        }
    }
}
