using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robber_2D
{
    interface IGameState
    {
        void Initialize();
        void LoadContent();
        void UnloadContent();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
