using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Robber_2D
{
    class EndScreen : GameState, IMenu
    {
        List<Button> AllButtons;
        SpriteFont buttonFont, scoreFont;
        Texture2D buttonBorder, resultImage;
        int leftMarginGameOver;
        string endScore;
        GameResult gameResult;

        public EndScreen(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game, GameResult gameResult) : base(contentManager, graphicsDevice, game)
        {
            this.gameResult = gameResult;
        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            if (gameResult == GameResult.Lost)
            {
                GameSounds.PlayGameOverSound();
            }

            GetScore();
            scoreFont = ContentManager.Load<SpriteFont>("DefaultFont");

            // Game Over Image
            if (gameResult == GameResult.Won)
            {
                resultImage = ContentManager.Load<Texture2D>("YouWin");
            }
            else
            {
                resultImage = ContentManager.Load<Texture2D>("GameOver");
            }

            leftMarginGameOver = (Robber2D.ScreenWidth - resultImage.Width) / 2;

            // Buttons
            AllButtons = new List<Button>();
            buttonBorder = ContentManager.Load<Texture2D>("ButtonBorder");
            buttonFont = ContentManager.Load<SpriteFont>("ButtonFont");

            int leftMarginButton = (Robber2D.ScreenWidth - buttonBorder.Width) / 2; // Center buttons on the screen

            // Create Buttons

            List<string> buttonTitles = new List<string>() { "SAVE SCORE", "BACK", "EXIT" };
            int yPos = 650;

            for (int i = 0; i < buttonTitles.Count; i++)
            {
                Button button = new Button(buttonBorder, buttonFont)
                {
                    Text = buttonTitles[i],
                    Position = new Vector2(leftMarginButton, yPos)
                };

                AllButtons.Add(button);
                yPos += 100;
            }

            AllButtons[0].Click += SaveScore;
            AllButtons[1].Click += ReturnToMenu;
            AllButtons[2].Click += CloseGame;      
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
            spriteBatch.Draw(resultImage, new Vector2(leftMarginGameOver, 200), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
        }

        private void DrawScore(SpriteBatch spriteBatch)
        {
            var x = ((Robber2D.ScreenWidth / 2)) - (scoreFont.MeasureString(endScore).X / 2);
            var y = ((Robber2D.ScreenHeight / 2)) - (scoreFont.MeasureString(endScore).Y / 2);
            spriteBatch.DrawString(scoreFont, endScore, new Vector2(x, y), Color.Red);
        }

        private void ReturnToMenu(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new StartScreen(ContentManager, GraphicsDevice, Game));
        }

        private void CloseGame(object sender, EventArgs e)
        {
            Game.Exit();
        }

        private void SaveScore(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            string fileName = "Score " + currentTime.ToString("MM-dd-yyyy_HH-mm-ss");

            string path = $@"c:\temp\{fileName}.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Robber 2D Score:");
                    sw.WriteLine(endScore);
                }
            }
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
