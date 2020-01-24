using Microsoft.Xna.Framework;

namespace Game_Development_Project
{
    class Camera2D
    {
        static public Matrix Transform;

        static public void Follow(Player player)
        {
            var position = Matrix.CreateTranslation(
               -player.SpriteSheet.Position.X - (player.CollisionRectangle.Height / 2),
               -player.SpriteSheet.Position.Y - (player.CollisionRectangle.Height / 2),
               0);

            var offset = Matrix.CreateTranslation(
                Robber2D.ScreenWidth / 2,
                Robber2D.ScreenHeight / 2,
                0);

            Transform = position * offset;
        }
    }
}

