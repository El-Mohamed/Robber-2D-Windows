using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game_Development_Project
{
    class Clock
    {
        int CountedTime, Minutes, Seconds;
        string TimeOutput;
        public SpriteFont Font;
        Vector2 ScreenTop;

        public Clock(SpriteFont font)
        {
            Font = font;
            TimeOutput = "00:00";
        }

        public void Update(GameTime gameTime)
        {
            UpdateTime(gameTime);
            UpdateTimeOuput();
        }

        private void UpdateTimeOuput()
        {
            string strMinutes = Convert.ToString(Minutes);
            string strSeconds = Convert.ToString(Seconds);

            if (Minutes < 10)
            {
                strMinutes = "0" + strMinutes;
            }

            if (Seconds < 10)
            {
                strSeconds = "0" + strSeconds;
            }

            TimeOutput = strMinutes + ":" + strSeconds;
        }

        private void UpdateTime(GameTime gameTime)
        {
            CountedTime += gameTime.ElapsedGameTime.Milliseconds;
            Minutes = CountedTime / 60000;
            Seconds = (CountedTime % 60000) / 1000;
        }

        public void UpdatePosition(Vector2 screenTop)
        {
            ScreenTop = screenTop;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, TimeOutput, ScreenTop, Color.White);
        }
    }
}
