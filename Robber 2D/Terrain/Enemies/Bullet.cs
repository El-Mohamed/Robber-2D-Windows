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
            Speed = Factory.CreateVector(20, 0);
            Damage = 10;
            direction = Direction.ToRight;
        }

        public void MoveRight()
        {
            Sprite.Position.X += Speed.X;
        }

        public void MoveLeft()
        {
            Sprite.Position.X -= Speed.X;
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
            CollisionRectangle = Factory.CreateRectangle((int)Sprite.Position.X, (int)Sprite.Position.Y, Sprite.Texture.Width, Sprite.Texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (direction == Direction.ToLeft)
            {
                spriteBatch.Draw(Sprite.Texture, Sprite.Position, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 1);
            }

            if (direction == Direction.ToRight)
            {
                spriteBatch.Draw(Sprite.Texture, Sprite.Position, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            }
        }
    }
}
