using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Robber_2D
{
    static class Factory
    {
        public static ContentManager contentManager;

        public static Vector2 CreateVector(float x, float y)
        {
            return new Vector2(x, y);
        }

        public static Rectangle CreateRectangle(int x, int y, int width, int height)
        {
            return new Rectangle(x, y, width, height);
        }

        static public Texture2D CreateTexture(string imageName)
        {
            Texture2D texture = contentManager.Load<Texture2D>(imageName);
            return texture;
        }

        public static Sprite CreateSprite(Texture2D texture, int numberOfSprites, Vector2 position)
        {
            return new Sprite(texture, numberOfSprites, position);
        }
    }
}
