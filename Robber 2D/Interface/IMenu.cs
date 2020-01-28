using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robber_2D
{
    interface IMenu
    {
        void DrawButtons(SpriteBatch spriteBatch);
        void UpdateButtons(GameTime gameTime);
        void DrawImages(SpriteBatch spriteBatch);
        void DrawText(SpriteBatch spriteBatch);
    }
}
