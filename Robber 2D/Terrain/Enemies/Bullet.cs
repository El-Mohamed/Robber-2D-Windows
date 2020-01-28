using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robber_2D
{
    class Bullet : Block, IMover
    {
        Vector2 Speed;
        public int Damage;
        public Direction direction;

        public Bullet(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
            Speed = Factory.CreateVector(15, 0);
            Damage = 10;
            direction = Direction.ToLeft;
        }

        public void MoveRight()
        {
            SpriteImage.Position.X += Speed.X;
        }

        public void MoveLeft()
        {
            SpriteImage.Position.X -= Speed.X;
        }

        private void UpdateMovement()
        {
            if (direction == Direction.ToLeft)
            {
                MoveLeft();
            }

            if (direction == Direction.ToRight)
            {
                MoveRight();
            }
        }

        public void Update(GameTime gameTime)
        {
            UpdateCollisionRectangle();
            UpdateMovement();
        }

        private void UpdateCollisionRectangle()
        {
            CollisionRectangle = Factory.CreateRectangle((int)SpriteImage.Position.X, (int)SpriteImage.Position.Y, SpriteImage.Texture1.Width, SpriteImage.Texture1.Height);
        }

    }
}
