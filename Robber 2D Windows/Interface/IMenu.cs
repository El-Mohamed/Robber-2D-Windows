using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robber_2D_Windows
{
    interface IMenu
    {
        void DrawButtons(SpriteBatch spriteBatch);
        void UpdateButtons(GameTime gameTime);
        void DrawImages(SpriteBatch spriteBatch);
        void DrawText(SpriteBatch spriteBatch);
    }
}
