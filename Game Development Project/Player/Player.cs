using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class Player
    {
        enum PlayerState { ToLeft, ToRight }

        private Controller controller;
        private Texture2D texture;
        private Vector2 position;
        private Animation animation;
        private bool isMoving;
        private PlayerState playerDirection;

        public Player(Texture2D texture, Vector2 position, Controller controller, Animation animation)
        {
            this.texture = texture;
            this.position = position;
            this.controller = controller;
            this.animation = animation;
            CreateAnimationFrames();
        }

        public void Update(GameTime gameTime)
        {
            controller.Update();
            isMoving = false;

            if (controller.Left)
            {
                MoveLeft();
                isMoving = true;
                playerDirection = PlayerState.ToLeft;
            }

            if (controller.Right)
            {
                MoveRight();
                isMoving = true;
                playerDirection = PlayerState.ToRight;
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
            position.X += 4;
        }
        public void MoveLeft()
        {
            position.X -= 4;
        }
    }
}
