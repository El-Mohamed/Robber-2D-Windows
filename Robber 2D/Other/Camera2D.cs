using Microsoft.Xna.Framework;

namespace Robber_2D
{
    class Camera2D
    {
        public Matrix Transform;

        public void Follow(Player player)
        {
            var position = Matrix.CreateTranslation(
               -player.Sprite.Position.X - (player.CollisionRectangle.Height / 2),
               -player.Sprite.Position.Y - (player.CollisionRectangle.Height / 2),
               0);

            var offset = Matrix.CreateTranslation(
                Robber2D.ScreenWidth / 2,
                Robber2D.ScreenHeight / 2,
                0);

            Transform = position * offset;
        }
    }
}

