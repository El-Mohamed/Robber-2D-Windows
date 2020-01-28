using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Robber_2D
{
    class StartScreen : GameState, IMenu
    {
        public List<Button> AllButtons;
        SpriteFont buttonFont;
        Button startButton, androidVersionButton, exitButton;
        Texture2D buttonBorder, logo;
        int leftMarginLogo;

        public StartScreen(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game) : base(contentManager, graphicsDevice, game)
        {

        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            AllButtons = new List<Button>();

            buttonBorder = ContentManager.Load<Texture2D>("ButtonBorder");
            buttonFont = ContentManager.Load<SpriteFont>("ButtonFont");
            logo = ContentManager.Load<Texture2D>("Logo");

            int leftMarginButton = (Robber2D.ScreenWidth - buttonBorder.Width) / 2; // Center buttons on the screen
            leftMarginLogo = (Robber2D.ScreenWidth - logo.Width) / 2;

            startButton = new Button(buttonBorder, buttonFont)
            {
                Text = "START GAME",
                Position = new Vector2(leftMarginButton, 550)
            };
            androidVersionButton = new Button(buttonBorder, buttonFont)
            {
                Text = "GOOGLE PLAY",
                Position = new Vector2(leftMarginButton, 650)
            };
            exitButton = new Button(buttonBorder, buttonFont)
            {
                Text = "EXIT",
                Position = new Vector2(leftMarginButton, 750)
            };

            AllButtons.Add(startButton);
            AllButtons.Add(androidVersionButton);
            AllButtons.Add(exitButton);

            exitButton.Click += CloseGame;
            androidVersionButton.Click += OpenGooglePlay;
            startButton.Click += StartGame;
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

        private void CloseGame(object sender, EventArgs e)
        {
            Game.Exit();
        }

        private void StartGame(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new InGame(ContentManager, GraphicsDevice, Game));
        }

        private void OpenGooglePlay(object sender, EventArgs e)
        {
            Process.Start("https://play.google.com/store/apps/details?id=com.mohamed.robber2D");
        }

        private void DrawLogo(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(logo, new Vector2(leftMarginLogo, 100), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
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
            DrawLogo(spriteBatch);
        }

        public void DrawText(SpriteBatch spriteBatch)
        {

        }
    }
}
