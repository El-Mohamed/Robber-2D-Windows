using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Robber_2D
{
    class Tank : Block
    {
        public List<Bullet> ShootedBullets;
        public int Health;
        public Direction Direction;

        public bool IsDestroyed
        {
            get
            {
                if (Health <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Tank(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
            ShootedBullets = new List<Bullet>();
            Health = 30;
            Direction = Direction.ToRight;
        }

        public void Shoot()
        {
            Texture2D bulletTexture = Factory.CreateTexture("Bullet");
            int yOffset = 10;
            int xOffset;

            if (Direction == Direction.ToLeft)
            {
                xOffset = -bulletTexture.Width;
            }
            else
            {
                xOffset = Sprite.Texture.Width;
            }

            Vector2 bulletPosition = Factory.CreateVector(Sprite.Position.X + xOffset, Sprite.Position.Y + yOffset);
            Rectangle bulletCollisoionRectangle = Factory.CreateRectangle((int)bulletPosition.X, (int)bulletPosition.Y, bulletTexture.Width, bulletTexture.Height);
            Sprite sprite = Factory.CreateSprite(bulletTexture, 1, bulletPosition);
            Bullet bullet = WorldFactory.CreateBullet(sprite, bulletCollisoionRectangle);
            bullet.direction = Direction;
            ShootedBullets.Add(bullet);
        }

        public void UpdateHealth(Bullet bullet)
        {
            Health -= bullet.Damage;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (Direction == Direction.ToLeft)
            {
                spriteBatch.Draw(Sprite.Texture, Sprite.Position, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 1);
            }

            if (Direction == Direction.ToRight)
            {
                spriteBatch.Draw(Sprite.Texture, Sprite.Position, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            }
        }
    }
}
