using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Robber_2D
{
    class WinScreen : GameState, IMenu
    {
        public List<Button> AllButtons;
        SpriteFont buttonFont;
        Button newGameButton, returnButton;
        Texture2D buttonBorder, winImage;
        int leftMarginGameOver;

        public WinScreen(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game) : base(contentManager, graphicsDevice, game)
        {

        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            // Game Over Image
            winImage = ContentManager.Load<Texture2D>("YouWin");
            leftMarginGameOver = (Robber2D.ScreenWidth - winImage.Width) / 2;

            // Buttons
            AllButtons = new List<Button>();
            buttonBorder = ContentManager.Load<Texture2D>("ButtonBorder");
            buttonFont = ContentManager.Load<SpriteFont>("ButtonFont");

            int leftMarginButton = (Robber2D.ScreenWidth - buttonBorder.Width) / 2; // Center buttons on the screen

            newGameButton = new Button(buttonBorder, buttonFont)
            {
                Text = "NEW GAME",
                Position = new Vector2(leftMarginButton, 650)

            };

            returnButton = new Button(buttonBorder, buttonFont)
            {
                Text = "RETURN",
                Position = new Vector2(leftMarginButton, 750)
            };


            AllButtons.Add(newGameButton);
            AllButtons.Add(returnButton);
            newGameButton.Click += StartNewGame;
            returnButton.Click += ReturnToMenu;

        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            UpdateButtons(gameTime);
        }
      
        public override void Draw(SpriteBatch spriteBatch)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            DrawButtons(spriteBatch);
            DrawImages(spriteBatch);
            DrawText(spriteBatch);

            spriteBatch.End();
        }

        private void DrawWinImage(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(winImage, new Vector2(leftMarginGameOver, 200), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
        }

        private void StartNewGame(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new InGame(ContentManager, GraphicsDevice, Game));
        }

        private void ReturnToMenu(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new StartScreen(ContentManager, GraphicsDevice, Game));
        }

        public void DrawButtons(SpriteBatch spriteBatch)
        {
            foreach (Button button in AllButtons)
            {
                button.Draw(spriteBatch);
            }
        }

        public void UpdateButtons(GameTime gameTime)
        {
            foreach (Button button in AllButtons)
            {
                button.Update(gameTime);
            }
        }

        public void DrawImages(SpriteBatch spriteBatch)
        {
            DrawWinImage(spriteBatch);
        }

        public void DrawText(SpriteBatch spriteBatch)
        {

        }
    }
}
