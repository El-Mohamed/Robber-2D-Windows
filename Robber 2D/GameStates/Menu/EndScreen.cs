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
        List<Button> allButtons;
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
            // Sound Effect

            if (gameResult == GameResult.Lost)
            {
                GameSounds.PlayGameOverSound();
            }

            // Score

            scoreFont = ContentManager.Load<SpriteFont>("DefaultFont");
            CalculateScore();

            // Result Image

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

            allButtons = new List<Button>();
            buttonBorder = ContentManager.Load<Texture2D>("ButtonBorder");
            buttonFont = ContentManager.Load<SpriteFont>("ButtonFont");

            int leftMarginButton = (Robber2D.ScreenWidth - buttonBorder.Width) / 2;

            List<string> buttonTitles = new List<string>() { "SAVE SCORE", "BACK", "EXIT" };
            int nextYPos = 650;

            for (int i = 0; i < buttonTitles.Count; i++)
            {
                Button button = new Button(buttonBorder, buttonFont)
                {
                    Text = buttonTitles[i],
                    Position = new Vector2(leftMarginButton, nextYPos)
                };

                allButtons.Add(button);
                nextYPos += 100;
            }

            allButtons[0].Click += SaveScore;
            allButtons[1].Click += ReturnToMenu;
            allButtons[2].Click += CloseGame;
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

        private void CalculateScore()
        {
            int DiamondsScore = InGame.player.Inventory.MyDiamonds * 200;
            int CoinsScore = InGame.player.Inventory.AllCoins.Count * 100;
            endScore = "TOTAL SCORE: " + Convert.ToString(DiamondsScore + CoinsScore);
        }

        private void DrawResultImage(SpriteBatch spriteBatch)
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

            // Folder

            string folderPath = @"c:\Robber2D";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // File

            DateTime currentTime = DateTime.Now;
            string fileName = "Score " + currentTime.ToString("MM-dd-yyyy_HH-mm-ss");

            string path = $@"c:\Robber2D\{fileName}.txt";

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
            foreach (Button button in allButtons)
            {
                button.Draw(spriteBatch);
            }
        }

        public void UpdateButtons(GameTime gameTime)
        {
            foreach (Button button in allButtons)
            {
                button.Update(gameTime);
            }
        }

        public void DrawImages(SpriteBatch spriteBatch)
        {
            DrawResultImage(spriteBatch);
        }

        public void DrawText(SpriteBatch spriteBatch)
        {
            DrawScore(spriteBatch);
        }
    }
}
