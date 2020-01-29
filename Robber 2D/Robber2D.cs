using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Robber_2D
{
    enum Direction { ToLeft, ToRight }
    enum GameMode { Hero, Tank }
    enum GameResult { Won, Lost }

    public class Robber2D : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static int ScreenHeight, ScreenWidth;

        public Robber2D()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
                PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height
            };
            Content.RootDirectory = "Content";
            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameStateManager.Instance.SetCurrentState(new StartScreen(Content, GraphicsDevice, this));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                GameStateManager.Instance.SetCurrentState(new StartScreen(Content, GraphicsDevice, this));

            // Mouse

            if (!(GameStateManager.Instance.GetCurrentState() is InGame))
            {
                IsMouseVisible = true;
            }
            else
            {
                IsMouseVisible = false;
            }

            // Instance

            GameStateManager.Instance.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GameStateManager.Instance.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
