﻿using Microsoft.Xna.Framework;

namespace Game_Development_Project
{
    static class ScreenPositionHelper
    {
        public static Vector2 GetScreenTop(Player player)
        {
            int OffSet = 15;
            return new Vector2(player.SpriteSheet.Position.X + OffSet, player.SpriteSheet.Position.Y - (Game1.ScreenHeight / 2) + 100);
        }

        public static Vector2 GetRightTopCorner(Player player)
        {
            return new Vector2(player.SpriteSheet.Position.X + (Game1.ScreenWidth / 2) - 10, player.SpriteSheet.Position.Y - (Game1.ScreenHeight / 2) + 100);
        }
    }
}