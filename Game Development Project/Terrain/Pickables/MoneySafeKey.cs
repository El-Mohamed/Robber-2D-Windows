using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Development_Project
{
    class MoneySafeKey : Block, ICloneable
    {
        public int MoneySafeID { get; set; }

        public MoneySafeKey(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
        }

        public object Clone()
        {
            return new MoneySafeKey(this.SpriteImage, this.CollisionRectangle) {
                MoneySafeID = this.MoneySafeID
            };         
        }
    }
}
