using Microsoft.Xna.Framework;

namespace Robber_2D_Windows
{
    abstract class Block : ICollider
    {
        public Rectangle CollisionRectangle { get; set; }
        public Sprite SpriteImage;
        public int ID;

        public Block(Sprite sprite, Rectangle collisionRectangle)
        {
            SpriteImage = sprite;
            CollisionRectangle = collisionRectangle;
        }
    }
}
