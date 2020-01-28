using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robber_2D
{
    static class Factory
    {
        public static Vector2 CreateVector(float x, float y)
        {
            return new Vector2(x, y);
        }

        public static Rectangle CreateRectangle(int x, int y, int width, int height)
        {
            return new Rectangle(x, y, width, height);
        }

        public static Sprite CreateSprite(Texture2D texture, int numberOfSprites, Vector2 position)
        {
            return new Sprite(texture, numberOfSprites, position);
        }
    }
}
