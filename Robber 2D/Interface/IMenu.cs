using Microsoft.Xna.Framework.Graphics;

namespace Robber_2D
{
    interface IMenu : IBasicMenu
    {
        void DrawImages(SpriteBatch spriteBatch);
        void DrawText(SpriteBatch spriteBatch);
    }
}
