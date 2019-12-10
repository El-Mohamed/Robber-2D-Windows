using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class Player : ICollider, IMover
    {
        enum PlayerState { ToLeft, ToRight }

        public Sprite SpriteSheet { get; set; }
        private Animation Animation { get; set; }
        private Controller Controller { get; set; }
        public Vector2 Speed { get; set; }
        public Inventory Inventory { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        private PlayerState PlayerDirection { get; set; }
        public int Health { get; set; }

        private bool IsMoving { get; set; }
        public bool CanMoveLeft { get; set; }
        public bool CanMoveRight { get; set; }
        public bool CanMoveDown { get; set; }

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
        }

        private void CreateAnimationFrames()
        {
            int OffSet = 0;
            int IndividualSpirteLength = SpriteSheet.Texture1.Width / SpriteSheet.NumberOfSprites;

            for (int i = 0; i < SpriteSheet.NumberOfSprites - 1; i++)
            {
                OffSet = (SpriteSheet.Texture1.Width / SpriteSheet.NumberOfSprites) * i;
                Animation.AddFrame(new Rectangle(OffSet, 0, IndividualSpirteLength, SpriteSheet.Texture1.Height));
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
            MoveDown();

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

        public void MoveDown()
        {
            if (CanMoveDown)
            {
                SpriteSheet.Position = new Vector2(SpriteSheet.Position.X, SpriteSheet.Position.Y + 4);
            }
        }

        public void UpdateHealth(Bullet bullet)
        {
            GameSounds.PlayHitSound();
            Health -= bullet.Damage;
        }

        public void Respawn()
        {
            SpriteSheet.Position = new Vector2(0, 50);
        }

        public void DrinkPotion()
        {
            if (Inventory.MyPotions.Count > 0)
            {
                Potion potionToDrink = Inventory.MyPotions[0];
                Speed = new Vector2(Speed.X + potionToDrink.SpeedAcceleration, Speed.Y);
                Inventory.MyPotions.RemoveAt(0); // Remove Drinked Potion
                GameSounds.PlayDrinkSound();
            }
        }
    }
}
