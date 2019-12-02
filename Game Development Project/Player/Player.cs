using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class Player: ICollider
    {
        enum PlayerState { ToLeft, ToRight }

        private Controller controller;
        private Texture2D texture;
        public Vector2 position;
        private Animation animation;
        private bool isMoving;
        private PlayerState playerDirection;
        private int walkSpeed;

        public Rectangle CollisionRectangle { get; set ; }

        public Player(Texture2D texture, Vector2 position, Controller controller, Animation animation, Rectangle collisionRectangle)
        {
            this.texture = texture;
            this.position = position;
            this.controller = controller;
            this.animation = animation;
            CreateAnimationFrames();
            CollisionRectangle = collisionRectangle;
            walkSpeed = 4;
        }

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

        }

        public void CreateAnimationFrames()
        {
            animation.AddFrame(new Rectangle(0, 0, 106, 150));
            animation.AddFrame(new Rectangle(106, 0, 106, 150));
            animation.AddFrame(new Rectangle(212, 0, 106, 150));
            animation.AddFrame(new Rectangle(318, 0, 106, 150));
            animation.AddFrame(new Rectangle(530, 0, 106, 150));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (playerDirection == PlayerState.ToLeft)
            {
                spriteBatch.Draw(texture, position, animation.currentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 1);
            }

            if (playerDirection == PlayerState.ToRight)
            {
                spriteBatch.Draw(texture, position, animation.currentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            }
        }

        public void MoveRight()
        {
            isMoving = true;
            playerDirection = PlayerState.ToRight;
            position.X += walkSpeed;
        }
        public void MoveLeft()
        {
            isMoving = true;
            playerDirection = PlayerState.ToLeft;
            position.X -= walkSpeed;
        }
    }
}
