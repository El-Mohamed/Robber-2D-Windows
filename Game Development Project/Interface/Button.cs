using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Development_Project
{
    public class Button
    {
        #region Fields

        private MouseState currentMouse;

        private SpriteFont spriteFont;

        private bool isHovering;

        private MouseState previousMouse;

        private Texture2D texture2D;

        #endregion

        #region Properties

        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color FontColor { get; set; }
        public Color ButtonColor { get; set; }
        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture2D.Width, texture2D.Height);
            }
        }

        public string Text { get; set; }

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
                FontColor = Color.White;
                ButtonColor = Color.Red;
            }
            else
            {
                FontColor = Color.Black;
                ButtonColor = Color.White;
            }
            
            spriteBatch.Draw(texture2D, Rectangle, ButtonColor);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (spriteFont.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (spriteFont.MeasureString(Text).Y / 2);

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