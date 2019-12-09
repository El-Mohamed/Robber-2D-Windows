using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class Clock
    {
        public int Time { get; set; }
        public SpriteFont SpriteFont { get; set; }
        public Vector2 Position { get; set; }

        public Clock(SpriteFont spriteFont)
        {
            SpriteFont = spriteFont;
            Time = 0;
        }

        public void UpdateTime(GameTime gameTime)
        {
            Time += gameTime.ElapsedGameTime.Milliseconds;
        }

        public void UpdatePosition(Player player)
        {
            Position = new Vector2(player.SpriteSheet.Position.X + 10, player.SpriteSheet.Position.Y - (Game1.ScreenHeight / 2) + 100);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, "Time: " + Time / 1000, Position, Color.Black);
        }

    }
}
