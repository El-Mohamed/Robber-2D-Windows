using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robber_2D
{
    class Player : ICollider, IMover
    {
        public Rectangle CollisionRectangle { get; set; }
        public Vector2 Speed;
        Direction direction;

        public Sprite Spirte;
        Animation Animation;
        Controller Controller;
        public Inventory Inventory;

        public int Health = 100;
        int AirTime = 0;
        public bool IsMoving, IsJumping, IsFallingDown;
        public bool CanMoveUp, CanMoveDown, CanMoveLeft, CanMoveRight;

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
            Spirte = sprite;
            Controller = controller;
            Animation = animation;
            CollisionRectangle = collisionRectangle;
            Speed = speed;
            Inventory = inventory;
            CreateAnimationFrames();
        }

        private void CreateAnimationFrames()
        {
            double OffSet = 0;
            int IndividualSpirteLength = Spirte.Texture1.Width / Spirte.NumberOfSprites;

            for (int i = 0; i < Spirte.NumberOfSprites - 1; i++)
            {
                OffSet = ((Spirte.Texture1.Width / Spirte.NumberOfSprites) * i);
                Animation.AddFrame(Factory.CreateRectangle((int)OffSet, 0, IndividualSpirteLength, Spirte.Texture1.Height));
            }
        }

        public void Update(GameTime gameTime)
        {
            Controller.Update();
            UpdateAnimation(gameTime);
            UpdateMovement(gameTime);
            UpdateCollisionRectangle();
        }

        private void UpdateAnimation(GameTime gameTime)
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
        }

        private void UpdateCollisionRectangle()
        {
            CollisionRectangle = Factory.CreateRectangle((int)Spirte.Position.X, (int)Spirte.Position.Y, Spirte.Texture1.Width / Spirte.NumberOfSprites, Spirte.Texture1.Height);
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
                spriteBatch.Draw(Spirte.Texture1, Spirte.Position, Animation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 1);
            }

            if (direction == Direction.ToRight)
            {
                spriteBatch.Draw(Spirte.Texture1, Spirte.Position, Animation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            }
        }

        public void MoveRight()
        {
            if (CanMoveRight)
            {
                IsMoving = true;

                if (IsFallingDown && !IsJumping)
                {
                    Spirte.Position.X += (Speed.X / 2);
                }
                else
                {
                    Spirte.Position.X += Speed.X;
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
                    Spirte.Position.X -= (Speed.X / 2);
                }
                else
                {
                    Spirte.Position.X -= Speed.X;
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

                Spirte.Position.Y += Speed.Y;
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
                    Spirte.Position.Y -= Speed.Y;
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
            Spirte.Position.X = 0;
            Spirte.Position.Y = -200;
        }

        public void DrinkPotion()
        {
            if (Inventory.Potion != null)
            {
                Speed.X += Inventory.Potion.SpeedAcceleration;
                Animation.IncreaseSpeed();
                Inventory.Potion = null; // Remove Drinked Potion
                GameSounds.PlayDrinkSound();            
            }
        }
    }
}
