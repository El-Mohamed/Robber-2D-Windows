using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Development_Project
{
    public abstract class GameState : IGameState
    {
        public ContentManager contentManager;
        public GraphicsDevice graphicsDevice;
        public Robber2D game;

        public GameState(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game)
        {
            this.graphicsDevice = graphicsDevice;
            this.contentManager = contentManager;
            this.game = game;
        }

        public abstract void Initialize();
        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
