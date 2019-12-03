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
        public Texture2D Texture1 { get; set; }
        public Vector2 Position { get; set; }
        public int ID { get; protected set; }
        public Rectangle CollisionRectangle { get; set; }

        public Block(Texture2D texture, Vector2 position, Rectangle collisonRectangle)
        {
            Texture1 = texture;
            Position = position;
            CollisionRectangle = collisonRectangle;
        }

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
