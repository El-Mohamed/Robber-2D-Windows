using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Robber_2D_Windows
{
    public abstract class GameState : IGameState
    {
        public ContentManager ContentManager;
        public GraphicsDevice GraphicsDevice;
        public Robber2D Game;

        public GameState(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game)
        {
            this.GraphicsDevice = graphicsDevice;
            this.ContentManager = contentManager;
            this.Game = game;
        }

        public abstract void Initialize();
        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
