using Microsoft.Xna.Framework;

namespace Robber_2D
{
    static class ScreenPosition
    {
        static int marginTop = 30, marginLeft = 30, marginRight = 70;

        public static Vector2 Top(Player player)
        {
            const int OffSet =- 40;
            float xPos = player.Sprite.Position.X + OffSet;
            float yPos = player.Sprite.Position.Y - (Robber2D.ScreenHeight / 2) + marginTop;
            return Factory.CreateVector(xPos, yPos);
        }

        public static Vector2 RightTopCorner(Player player)
        {
            float xPos = player.Sprite.Position.X + (Robber2D.ScreenWidth / 2) - marginRight;
            float yPos = player.Sprite.Position.Y - (Robber2D.ScreenHeight / 2) + marginTop;
            return Factory.CreateVector(xPos, yPos);
        }

        public static Vector2 LeftLopCorner(Player player)
        {
            float xPos = player.Sprite.Position.X - (Robber2D.ScreenWidth / 2) + marginLeft;
            float yPos = player.Sprite.Position.Y - (Robber2D.ScreenHeight / 2) + marginTop;
            return Factory.CreateVector(xPos, yPos);
        }
    }
}
