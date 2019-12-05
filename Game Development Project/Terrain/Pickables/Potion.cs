using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game_Development_Project
{
    class Potion : Block, ICloneable
    {
        public Potion(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
        }

        public int SpeedAcceleration { get; set; }

        public object Clone()
        {
            return new Potion(this.SpriteImage, this.CollisionRectangle)
            {
                SpeedAcceleration = this.SpeedAcceleration
            }; 
        }
    }
}
