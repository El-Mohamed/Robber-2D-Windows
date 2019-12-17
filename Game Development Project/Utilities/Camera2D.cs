using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class Camera2D
    {
        static public Matrix Transform { get; set; }

        static public void Follow(Player player)
        {
            var position = Matrix.CreateTranslation(
               -player.SpriteSheet.Position.X - (player.CollisionRectangle.Height / 2),
               -player.SpriteSheet.Position.Y - (player.CollisionRectangle.Height / 2),
               0);

            var offset = Matrix.CreateTranslation(
                Game1.ScreenWidth / 2,
                Game1.ScreenHeight / 2,
                0);

            Transform = position * offset;
        }
    }
}

