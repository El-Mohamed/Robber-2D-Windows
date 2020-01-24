using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    static class ScreenPositionHelper
    {
        public static Vector2 GetScreenTop(Player player)
        {
            int OffSet = 15;
            return new Vector2(player.SpriteSheet.Position.X + OffSet, player.SpriteSheet.Position.Y - (Game1.ScreenHeight / 2) + 100);
        }
    }
}
