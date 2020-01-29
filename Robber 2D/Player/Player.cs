using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Robber_2D
{
    class Player : ICollider, IMover
    {
        public Rectangle CollisionRectangle { get; set; }
        public Vector2 Speed;
        Direction direction;

        public Sprite Sprite;
        Animation Animation;
        Controller Controller;
        public Inventory Inventory;

        public int Health = 100;
        int AirTime = 0;
        public bool IsMoving, IsJumping, IsFallingDown;
        public bool CanMoveUp, CanMoveDown, CanMoveLeft, CanMoveRight;
        public List<Bullet> ShootedBullets;
        int LastTimeShooted;

        public bool IsDead
        {
            get
            {
                if (Health > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public Player(Sprite sprite, Controller controller, Animation animation, Rectangle collisionRectangle, Vector2 speed, Inventory inventory)
        {
            Sprite = sprite;
            Controller = controller;
            Animation = animation;
            CollisionRectangle = collisionRectangle;
            Speed = speed;
            Inventory = inventory;
            CreateAnimationFrames();
            ShootedBullets = new List<Bullet>();
        }

        private void CreateAnimationFrames()
        {
            double OffSet = 0;
            int IndividualSpirteLength = Sprite.Texture1.Width / Sprite.NumberOfSprites;

            if (Sprite.NumberOfSprites > 1)
            {
                for (int i = 0; i < Sprite.NumberOfSprites - 1; i++)
                {
                    OffSet = ((Sprite.Texture1.Width / Sprite.NumberOfSprites) * i);
                    Animation.AddFrame(Factory.CreateRectangle((int)OffSet, 0, IndividualSpirteLength, Sprite.Texture1.Height));
                }
            }
            else
            {
                OffSet = ((Sprite.Texture1.Width / Sprite.NumberOfSprites) * 0);
                Animation.AddFrame(Factory.CreateRectangle((int)OffSet, 0, IndividualSpirteLength, Sprite.Texture1.Height));
            }

        }

        public void Update(GameTime gameTime)
        {
            Controller.Update();
            UpdateAnimation(gameTime);
            UpdateMovement(gameTime);
            UpdateCollisionRectangle();
            UpdateBullets(gameTime);
            UpdateTimer(gameTime);
        }

        private void UpdateTimer(GameTime gameTime)
        {
            LastTimeShooted += 100 * gameTime.ElapsedGameTime.Milliseconds / 500;
        }

        private void UpdateAnimation(GameTime gameTime)
        {
            if (Sprite.NumberOfSprites > 1)
            {
                if (!IsMoving && !CanMoveDown)
                {
                    Animation.Freeze(0);
                }
                else if (IsMoving && !CanMoveDown)
                {
                    Animation.Update(gameTime);
                }
                else
                {
                    Animation.Freeze(4);
                }
            }
        }

        private void UpdateMovement(GameTime gameTime)
        {
            HandleJump();
            HandleGravity();
            UpdateController();
        }

        private void UpdateController()
        {
            IsMoving = false;

            if (Controller.Left)
            {
                MoveLeft();
            }

            if (Controller.Right)
            {
                MoveRight();
            }

            if (Controller.D)
            {
                DrinkPotion();
            }

            if (Controller.Space && IsJumping == false && !CanMoveDown)
            {
                IsJumping = true;
            }

            if (Controller.S)
            {
                Shoot();
            }
        }

        private void UpdateCollisionRectangle()
        {
            CollisionRectangle = Factory.CreateRectangle((int)Sprite.Position.X, (int)Sprite.Position.Y, Sprite.Texture1.Width / Sprite.NumberOfSprites, Sprite.Texture1.Height);
        }

        public void UpdateHealth(Bullet bullet)
        {
            GameSounds.PlayHitSound();
            Health -= bullet.Damage;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (direction == Direction.ToLeft)
            {
                spriteBatch.Draw(Sprite.Texture1, Sprite.Position, Animation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 1);
            }

            if (direction == Direction.ToRight)
            {
                spriteBatch.Draw(Sprite.Texture1, Sprite.Position, Animation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            }
            DrawBullets(spriteBatch);
        }

        private void DrawBullets(SpriteBatch spriteBatch)
        {
            foreach (Bullet bullet in ShootedBullets)
            {
                bullet.Draw(spriteBatch);
            }
        }

        private void UpdateBullets(GameTime gameTime)
        {
            foreach (Bullet bullet in ShootedBullets)
            {
                bullet.Update(gameTime);
            }
        }

        public void MoveRight()
        {
            if (CanMoveRight)
            {
                IsMoving = true;

                if (IsFallingDown && !IsJumping)
                {
                    Sprite.Position.X += (Speed.X / 2);
                }
                else
                {
                    Sprite.Position.X += Speed.X;
                }
            }

            direction = Direction.ToRight;
        }

        public void MoveLeft()
        {
            if (CanMoveLeft)
            {
                IsMoving = true;

                if (IsFallingDown && !IsJumping)
                {
                    Sprite.Position.X -= (Speed.X / 2);
                }
                else
                {
                    Sprite.Position.X -= Speed.X;
                }
            }

            direction = Direction.ToLeft;
        }

        public void HandleGravity()
        {
            if (!IsJumping && CanMoveDown)
            {
                IsFallingDown = true;

                if (AirTime < 20)
                {
                    AirTime++;

                    const float SPEED = 8;
                    float newSpeedY = Speed.Y + SPEED;
                    Speed.Y = newSpeedY;
                }

                Sprite.Position.Y += Speed.Y;
            }

            if (!CanMoveDown)
            {
                Speed.Y = 0;
                IsFallingDown = false;
                AirTime = 0;
            }
        }

        public void HandleJump()
        {
            Speed.Y = 10;

            if (IsJumping && AirTime < 25)
            {
                AirTime++;

                if (AirTime == 5)
                {
                    GameSounds.PlayJumpSound();
                }

                if (CanMoveUp)
                {
                    Sprite.Position.Y -= Speed.Y;
                }
                else
                {
                    StopJump();
                }
            }
            else
            {
                StopJump();
            }
        }

        private void StopJump()
        {
            AirTime = 0;
            IsJumping = false;
            Speed.Y = 0;
        }

        public void Respawn()
        {
            Sprite.Position.X = 0;
            Sprite.Position.Y = -200;
        }

        public void DrinkPotion()
        {
            if (Inventory.Potion != null)
            {
                Speed.X += Inventory.Potion.SpeedAcceleration;
                Animation.IncreaseSpeed();
                Inventory.Potion = null; 
                GameSounds.PlayDrinkSound();
            }
        }

        private void Shoot()
        {
            if (Sprite.NumberOfSprites == 1 && LastTimeShooted >= 250)
            {
                GameSounds.PlayShootSound();

                Texture2D bulletTexture = Factory.CreateTexture("Bullet");
                const int yOffset = 10; 
                int xOffset;

                if (direction == Direction.ToLeft)
                {
                    xOffset = -bulletTexture.Width;
                }
                else
                {
                    xOffset = Sprite.Texture1.Width;
                }

                Vector2 bulletPosition = Factory.CreateVector(Sprite.Position.X + xOffset, Sprite.Position.Y + yOffset);
                Rectangle bulletCollisoionRectangle = Factory.CreateRectangle((int)bulletPosition.X, (int)bulletPosition.Y, bulletTexture.Width, bulletTexture.Height);
                Sprite sprite = Factory.CreateSprite(bulletTexture, 1, bulletPosition);
                Bullet bullet = WorldFactory.CreateBullet(sprite, bulletCollisoionRectangle);
                bullet.direction = direction;
                ShootedBullets.Add(bullet);
                LastTimeShooted = 0;
            }
        }
    }
}
