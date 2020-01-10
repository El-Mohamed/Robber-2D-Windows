using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Development_Project
{
    class Player : ICollider, IMover
    {
        enum PlayerState { ToLeft, ToRight }
        public Vector2 Speed { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        public Sprite SpriteSheet;
        private Animation Animation;
        private Controller Controller;    
        public Inventory Inventory;

        private PlayerState PlayerDirection;
        public int Health;
        public int AirTime;
        public bool IsMoving, IsJumping;
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

        public Player(Sprite spriteSheet, Controller controller, Animation animation, Rectangle collisionRectangle, Vector2 speed, Inventory inventory)
        {
            SpriteSheet = spriteSheet;
            Controller = controller;
            Animation = animation;
            CollisionRectangle = collisionRectangle;
            Speed = speed;
            Inventory = inventory;
            CreateAnimationFrames();
            Health = 100;
            CanMoveLeft = false;
            CanMoveRight = false;
            CanMoveDown = false;
            IsJumping = false;
            AirTime = 0;
        }

        private void CreateAnimationFrames()
        {
            double OffSet = 0;
            int IndividualSpirteLength = SpriteSheet.Texture1.Width / SpriteSheet.NumberOfSprites;

            for (int i = 0; i < SpriteSheet.NumberOfSprites - 1; i++)
            {
                OffSet = ((SpriteSheet.Texture1.Width / SpriteSheet.NumberOfSprites) * i);
                Animation.AddFrame(new Rectangle((int)OffSet, 0, IndividualSpirteLength, SpriteSheet.Texture1.Height));
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
                Animation.currentFrame = Animation.allFrames[0];
            }
            else if (IsMoving && !CanMoveDown)
            {
                Animation.Update(gameTime);
            }
            else
            {
                Animation.currentFrame = Animation.allFrames[4];
            }
        }

        private void UpdateMovement(GameTime gameTime)
        {

            HandleJump();
            HandleGravity();

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
            CollisionRectangle = new Rectangle((int)SpriteSheet.Position.X, (int)SpriteSheet.Position.Y, SpriteSheet.Texture1.Width / SpriteSheet.NumberOfSprites, SpriteSheet.Texture1.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (PlayerDirection == PlayerState.ToLeft)
            {
                spriteBatch.Draw(SpriteSheet.Texture1, SpriteSheet.Position, Animation.currentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 1);
            }

            if (PlayerDirection == PlayerState.ToRight)
            {
                spriteBatch.Draw(SpriteSheet.Texture1, SpriteSheet.Position, Animation.currentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            }
        }

        public void MoveRight()
        {
            if (CanMoveRight)
            {
                IsMoving = true;
                SpriteSheet.Position = new Vector2(SpriteSheet.Position.X + Speed.X, SpriteSheet.Position.Y);
            }

            PlayerDirection = PlayerState.ToRight;
        }

        public void MoveLeft()
        {
            if (CanMoveLeft)
            {
                IsMoving = true;
                SpriteSheet.Position = new Vector2(SpriteSheet.Position.X - Speed.X, SpriteSheet.Position.Y);
            }

            PlayerDirection = PlayerState.ToLeft;
        }

        public void HandleGravity()
        {
            if (!IsJumping && CanMoveDown)
            {
                if (AirTime < 20)
                {
                    AirTime++;

                    float MULTIPLIER = 8;
                    float newSpeedY = Speed.Y;
                    newSpeedY += 1 * MULTIPLIER;
                    Speed = new Vector2(Speed.X, newSpeedY);
                }

                SpriteSheet.Position = new Vector2(SpriteSheet.Position.X, SpriteSheet.Position.Y + Speed.Y);
            }

            if (!CanMoveDown)
            {
                Speed = new Vector2(Speed.X, 0);
                IsJumping = false;
                AirTime = 0;
            }
        }

        public void HandleJump()
        {
            if (IsJumping && AirTime < 25)
            {
                AirTime++;

                if (CanMoveUp)
                {
                    SpriteSheet.Position = new Vector2(SpriteSheet.Position.X, SpriteSheet.Position.Y - 10);
                }
                else
                {
                    Speed = new Vector2(Speed.X, 0);
                    IsJumping = false;
                }
            }
            else
            {
                AirTime = 0;
                IsJumping = false;
                Speed = new Vector2(Speed.X, 0);
            }
        }

        public void UpdateHealth(Bullet bullet)
        {
            GameSounds.PlayHitSound();
            Health -= bullet.Damage;
        }

        public void Respawn()
        {
            SpriteSheet.Position = new Vector2(0, -200);
        }

        public void DrinkPotion()
        {
            if (Inventory.MyPotion != null)
            {
                Potion potionToDrink = Inventory.MyPotion;
                Speed = new Vector2(Speed.X + potionToDrink.SpeedAcceleration, Speed.Y);
                Inventory.MyPotion = null; // Remove Drinked Potion
                GameSounds.PlayDrinkSound();
            }
        }
    }
}
