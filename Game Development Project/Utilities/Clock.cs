using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game_Development_Project
{
    class Clock
    {
        static public int Time;
        static public string TimeText = "";
        static public SpriteFont SpriteFont;
        static public Vector2 Position;

        static public void UpdateTime(GameTime gameTime)
        {
            Time += gameTime.ElapsedGameTime.Milliseconds;

            int minutes = Time / 60000;
            int seconds = (Time % 60000) / 1000;
            string strMinutes = Convert.ToString(minutes);
            string strSeconds = Convert.ToString(seconds);

            if (minutes < 10)
            {
                strMinutes = "0" + strMinutes;
            }

            if (seconds < 10)
            {
                strSeconds = "0" + strSeconds;
            }

            TimeText = strMinutes + ":" + strSeconds;
        }

        static public void UpdatePosition(Player player)
        {
            int OffSet = 15;
            Position = new Vector2(player.SpriteSheet.Position.X + OffSet, player.SpriteSheet.Position.Y - (Game1.ScreenHeight / 2) + 100);
        }

        static public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, TimeText, Position, Color.White);
        }
    }
}
