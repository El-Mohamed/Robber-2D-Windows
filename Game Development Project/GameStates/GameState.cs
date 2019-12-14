using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    public abstract class GameState: IGameState
    {
       public ContentManager contentManager { get; set; }
       public  GraphicsDevice graphicsDevice { get; set; }
       public Game1 game { get; set; }

        public GameState(ContentManager contentManager, GraphicsDevice graphicsDevice, Game1 game)
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
