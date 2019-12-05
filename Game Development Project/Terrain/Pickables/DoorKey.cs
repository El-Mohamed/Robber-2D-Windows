using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Development_Project
{
    class DoorKey : Block, ICloneable
    {
        public DoorKey(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
        }

        public bool IsCorrect { get; set; }

        public object Clone()
        {
            return new DoorKey(this.SpriteImage, this.CollisionRectangle)
            {
                IsCorrect = this.IsCorrect
            }; ;
        }
    }
}
