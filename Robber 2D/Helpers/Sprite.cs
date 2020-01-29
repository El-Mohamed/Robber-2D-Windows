using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robber_2D
{
    class Sprite
    {
        public int NumberOfSprites;
        public Texture2D Texture;
        public Vector2 Position;

        public Sprite(Texture2D texture, int numberOfSprites, Vector2 position)
        {
            NumberOfSprites = numberOfSprites;
            Texture = texture;
            Position = position;
        }

        public Sprite(Texture2D texture, Vector2 position)
        {
            NumberOfSprites = 1;
            Texture = texture;
            Position = position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
