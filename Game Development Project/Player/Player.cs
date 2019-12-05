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

        private Controller Controller { get; set; }
        private Animation Animation { get; set; }
        private bool IsMoving { get; set; }
        public Sprite SpriteSheet { get; set; }
        private PlayerState PlayerDirection { get; set; }
        public Vector2 Speed { get; set; }
        public Inventory Inventory { get; set; }

        public Rectangle CollisionRectangle { get; set; }


        public Player(Sprite spriteSheet, Controller controller, Animation animation, Rectangle collisionRectangle, Vector2 speed, Inventory inventory)
        {
            SpriteSheet = spriteSheet;
            Controller = controller;
            Animation = animation;
            CollisionRectangle = collisionRectangle;
            Speed = speed;
            Inventory = inventory;
            CreateAnimationFrames();
        }

        public void ResetPositon()
        {
            SpriteSheet.Position = new Vector2(0, 0);
        }

        public void Update(GameTime gameTime)
        {
            FallDown();
            Controller.Update();
            IsMoving = false;

            if (Controller.Left)
            {
                MoveLeft();
            }

            if (Controller.Right)
            {
                MoveRight();
            }

            if (IsMoving)
            {
                Animation.Update(gameTime);
            }

            CollisionRectangle = new Rectangle((int)SpriteSheet.Position.X, (int)SpriteSheet.Position.Y, SpriteSheet.Texture1.Width / SpriteSheet.NumberOfSprites, SpriteSheet.Texture1.Height);

        }

        public void CreateAnimationFrames()
        {
            int OffSet = 0;
            int IndividualSpirteLength = SpriteSheet.Texture1.Width / SpriteSheet.NumberOfSprites;

            for (int i = 0; i < SpriteSheet.NumberOfSprites - 1; i++)
            {
                OffSet = (SpriteSheet.Texture1.Width / SpriteSheet.NumberOfSprites) * i;
                Animation.AddFrame(new Rectangle(OffSet, 0, IndividualSpirteLength, SpriteSheet.Texture1.Height));
            }
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
          
                IsMoving = true;
                SpriteSheet.Position = new Vector2(SpriteSheet.Position.X + Speed.X, SpriteSheet.Position.Y);
         

            PlayerDirection = PlayerState.ToRight;
        }

        public void MoveLeft()
        {
           
                IsMoving = true;
                SpriteSheet.Position = new Vector2(SpriteSheet.Position.X - Speed.X, SpriteSheet.Position.Y);
           

            PlayerDirection = PlayerState.ToLeft;

        }

        public void FallDown()
        {
            SpriteSheet.Position = new Vector2(SpriteSheet.Position.X, SpriteSheet.Position.Y + Speed.Y);
        }

        public void SetFallSpeed(bool state)
        {
            if (state)
            {
                Speed = new Vector2(Speed.X, 0);
            }
            else
            {
                Speed = new Vector2(Speed.X, 1);
            }
        }

    }
}
