using Microsoft.Xna.Framework;

namespace Game_Development_Project
{
    static class ScreenPositionHelper
    {
        public static Vector2 GetScreenTop(Player player)
        {
            int OffSet = 15;
            return new Vector2(player.SpriteSheet.Position.X + OffSet, player.SpriteSheet.Position.Y - (Robber2D.ScreenHeight / 2) + 100);
        }

        public static Vector2 GetRightTopCorner(Player player)
        {
            return new Vector2(player.SpriteSheet.Position.X + (Robber2D.ScreenWidth / 2) - 10, player.SpriteSheet.Position.Y - (Robber2D.ScreenHeight / 2) + 100);
        }

        public static Vector2 GetLeftScreenCorner(Player player)
        {
            return new Vector2(player.SpriteSheet.Position.X - (Robber2D.ScreenWidth / 2) + 100, player.SpriteSheet.Position.Y - (Robber2D.ScreenHeight / 2) + 100);
        }
    }
}
