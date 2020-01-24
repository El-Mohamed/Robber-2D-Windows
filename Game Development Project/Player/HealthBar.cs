using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Development_Project
{
    class HealthBar
    {
        public Texture2D HeartTexture;
        public Vector2 RightTopCorner;
        public int HealthLevel;

        public HealthBar(Texture2D heartTexture)
        {
            HeartTexture = heartTexture;
            HealthLevel = 0;
        }

        public void UpdatePosition(Vector2 rightTopCorner)
        {
            RightTopCorner = rightTopCorner;
        }

        public void SetHealth(Player player)
        {
            HealthLevel = player.Health;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (HealthLevel > 0)
            {
                for (int i = 0; i < HealthLevel / 10; i++)
                {
                    Vector2 tempVector = new Vector2(RightTopCorner.X - (i * (HeartTexture.Width + 10)), RightTopCorner.Y);
                    Sprite tempSprite = new Sprite(HeartTexture, 1, tempVector);
                    tempSprite.Draw(spriteBatch);
                }
            }
        }
    }
}
