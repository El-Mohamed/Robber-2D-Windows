using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robber_2D
{
    interface IBasicMenu
    {
        void DrawButtons(SpriteBatch spriteBatch);
        void UpdateButtons(GameTime gameTime);
    }
}
