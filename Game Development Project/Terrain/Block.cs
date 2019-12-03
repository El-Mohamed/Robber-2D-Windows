using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    abstract class Block : Sprite, ICollider
    {
        public Rectangle CollisionRectangle { get; set; }

        public Block(Texture2D texture, Vector2 position, Rectangle collisionRectangle) : base(texture, position)
        {
            CollisionRectangle = collisionRectangle;
        }

        public int ID { get; protected set; }
        

       

      

    }
}
