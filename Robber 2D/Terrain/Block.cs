using Microsoft.Xna.Framework;

namespace Robber_2D
{
    abstract class Block : ICollider
    {
        public Rectangle CollisionRectangle { get; set; }
        public Sprite Sprite;
        public int ID;

        public Block(Sprite sprite, Rectangle collisionRectangle)
        {
            Sprite = sprite;
            CollisionRectangle = collisionRectangle;
        }
    }
}
