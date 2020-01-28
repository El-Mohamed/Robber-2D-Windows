using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robber_2D
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
                    Vector2 tempVector = Factory.CreateVector(RightTopCorner.X - (i * (HeartTexture.Width + 10)), RightTopCorner.Y);
                    Sprite tempSprite = Factory.CreateSprite(HeartTexture, 1, tempVector);
                    tempSprite.Draw(spriteBatch);
                }
            }
        }
    }
}
