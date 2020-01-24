using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Development_Project
{
    class WinScreen : GameState
    {
        SpriteFont buttonFont;
        Button newGameButton, returnButton;
        Texture2D buttonBorder, GameOverImage;
        private int leftMarginGameOver;
        public List<Button> AllButtons;

        public WinScreen(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game) : base(contentManager, graphicsDevice, game)
        {

        }

        public override void Initialize()
        {

        }
        public override void LoadContent()
        {
            // Game Over Image
            GameOverImage = contentManager.Load<Texture2D>("YouWin");
            leftMarginGameOver = (Robber2D.ScreenWidth - GameOverImage.Width) / 2;

            // Buttons
            AllButtons = new List<Button>();
            buttonBorder = contentManager.Load<Texture2D>("ButtonBorder");
            buttonFont = contentManager.Load<SpriteFont>("ButtonFont");

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
            foreach (Button button in AllButtons)
            {
                button.Update(gameTime);
            }
        }

        private void DrawGameOverText(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GameOverImage, new Vector2(leftMarginGameOver, 200), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            DrawGameOverText(spriteBatch);

            foreach (Button button in AllButtons)
            {
                button.Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        private void StartNewGame(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new InGame(contentManager, graphicsDevice, game));
        }

        private void ReturnToMenu(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new StartScreen(contentManager, graphicsDevice, game));
        }
    }
}
