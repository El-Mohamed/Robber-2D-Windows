using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Game_Development_Project
{
    class EndScreen : GameState
    {

        SpriteFont buttonFont;
        Button newGameButton, closeGameButton;
        Texture2D buttonBorder, GameOverImage;
        private int leftMarginGameOver;
        string EndScore;
        public List<Button> AllButtons;

        public EndScreen(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game) : base(contentManager, graphicsDevice, game)
        {

        }

        public override void Initialize()
        {

        }
        public override void LoadContent()
        {

            GetScore();

            // Game Over Image
            GameOverImage = contentManager.Load<Texture2D>("GameOver");
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

            closeGameButton = new Button(buttonBorder, buttonFont)
            {
                Text = "CLOSE GAME",
                Position = new Vector2(leftMarginButton, 750)

            };

            AllButtons.Add(closeGameButton);
            AllButtons.Add(newGameButton);

            closeGameButton.Click += CloseGame;
            newGameButton.Click += StartNewGame;

            GameSounds.PlayGameOverSound();

        }

        private void GetScore()
        {
            int DiamondsScore = InGame.player.Inventory.MyDiamonds * 200;
            int CoinsScore = InGame.player.Inventory.MyCoins.Count * 100;
            EndScore = "TOTAL SCORE: " + Convert.ToString(DiamondsScore + CoinsScore);
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

        private void DrawScore(SpriteBatch spriteBatch)
        {
            var x = ((Robber2D.ScreenWidth / 2)) - (buttonFont.MeasureString(EndScore).X / 2);
            var y = ((Robber2D.ScreenHeight / 2)) - (buttonFont.MeasureString(EndScore).Y / 2);
            spriteBatch.DrawString(buttonFont, EndScore, new Vector2(x, y), Color.Red);
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

            DrawScore(spriteBatch);

            spriteBatch.End();
        }

        private void CloseGame(object sender, EventArgs e)
        {
            game.Exit();
        }

        private void StartNewGame(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new InGame(contentManager, graphicsDevice, game));
        }
    }
}
