using Microsoft.Xna.Framework;

namespace Robber_2D_Windows
{
    static class ScreenPositionHelper
    {
        public static Vector2 GetScreenTop(Player player)
        {
            int OffSet = 15;
            return new Vector2(player.Spirte.Position.X + OffSet, player.Spirte.Position.Y - (Robber2D.ScreenHeight / 2) + 100);
        }

        public static Vector2 GetRightTopCorner(Player player)
        {
            return new Vector2(player.Spirte.Position.X + (Robber2D.ScreenWidth / 2) - 10, player.Spirte.Position.Y - (Robber2D.ScreenHeight / 2) + 100);
        }

        public static Vector2 GetLeftScreenCorner(Player player)
        {
            return new Vector2(player.Spirte.Position.X - (Robber2D.ScreenWidth / 2) + 100, player.Spirte.Position.Y - (Robber2D.ScreenHeight / 2) + 100);
        }
    }
}
