using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Robber_2D
{
    public class Button
    {
        public Rectangle Rectangle => Factory.CreateRectangle((int)Position.X, (int)Position.Y, border.Width, border.Height);

        MouseState currentMouse, previousMouse;
        public Vector2 Position;
        SpriteFont font;
        Texture2D border;
        public event EventHandler Click;
        public bool Clicked, isHovering;
        Color fontColor, buttonColor;
        public string Text;

        public Button(Texture2D texture, SpriteFont font)
        {
            border = texture;
            this.font = font;
            fontColor = Color.Black;
            buttonColor = Color.White;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawBorder(spriteBatch);
            DrawText(spriteBatch);
        }

        private void DrawBorder(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(border, Rectangle, buttonColor);
        }

        private void DrawText(SpriteBatch spriteBatch)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                float x = (Rectangle.X + (Rectangle.Width / 2)) - (font.MeasureString(Text).X / 2);
                float y = (Rectangle.Y + (Rectangle.Height / 2)) - (font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(font, Text, new Vector2(x, y), fontColor);
            }
        }

        public void Update(GameTime gameTime)
        {
            UpdateColors();
            UpdateMouse();
        }

        private void UpdateColors()
        {
            if (isHovering)
            {
                fontColor = Color.Red;
                buttonColor = Color.White;
            }
            else
            {
                fontColor = Color.White;
                buttonColor = Color.Red;
            }
        }

        private void UpdateMouse()
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            Rectangle mouseRectangle = Factory.CreateRectangle(currentMouse.X, currentMouse.Y, 1, 1);

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
    }
}