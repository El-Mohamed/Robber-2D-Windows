using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    abstract class Block : ICollider
    {
        public Rectangle CollisionRectangle { get; set; }
        public Sprite SpriteImage { get; set; }

        public Block(Sprite sprite, Rectangle collisionRectangle)
        {
            SpriteImage = sprite;
            CollisionRectangle = collisionRectangle;
        }

        public int ID { get; protected set; }
    }
}
