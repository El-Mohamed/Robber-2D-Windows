using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class Player : Sprite, ICollider
    {
        enum PlayerState { ToLeft, ToRight }

        private Controller controller;
        private Animation animation;
        private bool isMoving;
        private PlayerState playerDirection;
        public Vector2 Speed { get; set; }

        public Player(Texture2D texture, Vector2 position, Controller controller, Animation animation, Rectangle collisionRectangle, Vector2 speed) : base(texture, position)
        {
            this.controller = controller;
            this.animation = animation;
            CreateAnimationFrames();
            CollisionRectangle = collisionRectangle;
            Speed = speed;
        }

        public Rectangle CollisionRectangle { get; set; }

        public void Update(GameTime gameTime)
        {
            controller.Update();
            isMoving = false;

            if (controller.Left)
            {
                MoveLeft();
            }

            if (controller.Right)
            {
                MoveRight();
            }

            if (isMoving)
            {
                animation.Update(gameTime);
            }

            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture1.Width, Texture1.Height);

        }

        public void CreateAnimationFrames()
        {
            animation.AddFrame(new Rectangle(0, 0, 106, 150));
            animation.AddFrame(new Rectangle(106, 0, 106, 150));
            animation.AddFrame(new Rectangle(212, 0, 106, 150));
            animation.AddFrame(new Rectangle(318, 0, 106, 150));
            animation.AddFrame(new Rectangle(530, 0, 106, 150));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (playerDirection == PlayerState.ToLeft)
            {
                spriteBatch.Draw(Texture1, Position, animation.currentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 1);
            }

            if (playerDirection == PlayerState.ToRight)
            {
                spriteBatch.Draw(Texture1, Position, animation.currentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            }
        }

        public void MoveRight()
        {
            isMoving = true;
            playerDirection = PlayerState.ToRight;
            Position = new Vector2(Position.X + Speed.X, Position.Y);
        }
        public void MoveLeft()
        {
            isMoving = true;
            playerDirection = PlayerState.ToLeft;
            Position = new Vector2(Position.X - Speed.X, Position.Y);
        }


    }
}
