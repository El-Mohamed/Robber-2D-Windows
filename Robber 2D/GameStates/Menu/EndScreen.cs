using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Robber_2D
{
    class EndScreen : GameState, IMenu
    {
        public List<Button> AllButtons;
        SpriteFont buttonFont;
        Button newGameButton, closeGameButton;
        Texture2D buttonBorder, GameOverImage;
        int leftMarginGameOver;
        string endScore;
        
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
            GameOverImage = ContentManager.Load<Texture2D>("GameOver");
            leftMarginGameOver = (Robber2D.ScreenWidth - GameOverImage.Width) / 2;

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

        private void GetScore()
        {
            int DiamondsScore = InGame.player.Inventory.MyDiamonds * 200;
            int CoinsScore = InGame.player.Inventory.AllCoins.Count * 100;
            endScore = "TOTAL SCORE: " + Convert.ToString(DiamondsScore + CoinsScore);
        }

        private void DrawGameOverImage(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GameOverImage, new Vector2(leftMarginGameOver, 200), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
        }

        private void DrawScore(SpriteBatch spriteBatch)
        {
            var x = ((Robber2D.ScreenWidth / 2)) - (buttonFont.MeasureString(endScore).X / 2);
            var y = ((Robber2D.ScreenHeight / 2)) - (buttonFont.MeasureString(endScore).Y / 2);
            spriteBatch.DrawString(buttonFont, endScore, new Vector2(x, y), Color.Red);
        }

        private void StartNewGame(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new InGame(ContentManager, GraphicsDevice, Game));
        }

        private void CloseGame(object sender, EventArgs e)
        {
            Game.Exit();
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
            DrawGameOverImage(spriteBatch);
        }

        public void DrawText(SpriteBatch spriteBatch)
        {
            DrawScore(spriteBatch);
        }
    }
}
