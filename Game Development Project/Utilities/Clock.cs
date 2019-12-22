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
        static public int Time { get; set; }
        static public SpriteFont SpriteFont { get; set; }
        static public Vector2 Position { get; set; }

        static public void UpdateTime(GameTime gameTime)
        {
            Time += gameTime.ElapsedGameTime.Milliseconds;
        }

        static public void UpdatePosition(Player player)
        {
            Position = new Vector2(player.SpriteSheet.Position.X + 10, player.SpriteSheet.Position.Y - (Game1.ScreenHeight / 2) + 100);
        }

        static public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, "Time: " + Time / 1000, Position, Color.White);
        }

    }
}
