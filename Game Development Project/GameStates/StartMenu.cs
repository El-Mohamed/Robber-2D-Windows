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
    class StartMenu : GameState
    {
        #region Fields

        public List<Button> AllButtons { get; set; }
        private Texture2D buttonBorder;
        private SpriteFont buttonFont;
        private Button startButton, settingsButton, exitButton;
        private Texture2D logo;
        private int leftMarginLogo;

        #endregion
        public StartMenu(ContentManager contentManager, GraphicsDevice graphicsDevice, Game1 game) : base(contentManager, graphicsDevice, game)
        {
        
        }

        public override void Initialize()
        {
        
        }

        public override void LoadContent()
        {
            AllButtons = new List<Button>();

            buttonBorder = contentManager.Load<Texture2D>("ButtonBorder");
            buttonFont = contentManager.Load<SpriteFont>("ButtonFont");
            logo = contentManager.Load<Texture2D>("Logo");

            int leftMarginButton = (Game1.ScreenWidth - buttonBorder.Width) / 2; // Center buttons on the screen
            leftMarginLogo = (Game1.ScreenWidth - logo.Width) / 2;

            startButton = new Button(buttonBorder, buttonFont)
            {
                Text = "START GAME",
                Position = new Vector2(leftMarginButton, 400)
            };
            settingsButton = new Button(buttonBorder, buttonFont)
            {
                Text = "SETTINGS",
                Position = new Vector2(leftMarginButton, 500)
            };
            exitButton = new Button(buttonBorder, buttonFont)
            {
                Text = "EXIT",
                Position = new Vector2(leftMarginButton, 600)
            };

            AllButtons.Add(startButton);
            AllButtons.Add(settingsButton);
            AllButtons.Add(exitButton);

            exitButton.Click += CloseGame;
            startButton.Click += StartGame;
        }

        private void CloseGame(object sender, EventArgs e)
        {
            game.Exit();
        }

        private void StartGame(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new InGame(contentManager, graphicsDevice, game));
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

        private void DrawLogo(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(logo, new Vector2(leftMarginLogo, 100), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.White);
            spriteBatch.Begin();

            DrawLogo(spriteBatch);

            foreach (Button b in AllButtons)
            {

                b.Draw(spriteBatch);
            }

            spriteBatch.End();
        }
    }
}
