using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Game_Development_Project
{
    public class Button
    {
        #region Fields
        public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, texture2D.Width, texture2D.Height);

        private MouseState currentMouse, previousMouse;
        public Vector2 Position;
        private SpriteFont spriteFont;
        private Texture2D texture2D;
        public event EventHandler Click;
        public bool Clicked, isHovering;
        public Color FontColor, ButtonColor;
        public string Text;

        #endregion

        #region Methods

        public Button(Texture2D texture, SpriteFont font)
        {
            texture2D = texture;
            spriteFont = font;
            FontColor = Color.Black;
            ButtonColor = Color.White;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isHovering)
            {
                FontColor = Color.Red;
                ButtonColor = Color.White;
            }
            else
            {
                FontColor = Color.White;
                ButtonColor = Color.Red;
            }

            spriteBatch.Draw(texture2D, Rectangle, ButtonColor);

            if (!string.IsNullOrEmpty(Text))
            {
                float x = (Rectangle.X + (Rectangle.Width / 2)) - (spriteFont.MeasureString(Text).X / 2);
                float y = (Rectangle.Y + (Rectangle.Height / 2)) - (spriteFont.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(spriteFont, Text, new Vector2(x, y), FontColor);
            }
        }

        public void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            Rectangle mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                isHovering = true;

                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }

        #endregion
    }
}