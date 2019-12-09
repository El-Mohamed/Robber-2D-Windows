using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game_Development_Project
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        List<Level> AllLevels;
        private Camera camera;
        public static int ScreenHeight;
        public static int ScreenWidth;
        public static int CurrentLevel;
        CollisionManager collisionManager;
        InventoryHelper inventroyHelper;
        Healtbar healtbar;
        Clock clock;


        public Game1()
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

            // Player 1

            int spriteSheetLength = 6;
            Texture2D playerTexture = Content.Load<Texture2D>("PlayerSpriteSheet");
            Controller playerController = new Controller();
            Vector2 playerPosition = new Vector2(0, 0);
            Vector2 playerSpeed = new Vector2(4, 1);
            Animation playerAnimation = new Animation();
            Sprite playerSprite = new Sprite(playerTexture, 6, playerPosition);
            Rectangle playerCollisonRectangle = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerTexture.Width / spriteSheetLength, playerTexture.Height);
            Inventory playerInventory = new Inventory();
            player = new Player(playerSprite, playerController, playerAnimation, playerCollisonRectangle, playerSpeed, playerInventory);

            // Other

            AllLevels = new List<Level>();
            CurrentLevel = 0;
            camera = new Camera();
            collisionManager = new CollisionManager();
            clock = new Clock();

            // Inventory Helper & Healthbar

            inventroyHelper = new InventoryHelper(player.Inventory);
            healtbar = new Healtbar();

            // Level 1

            byte[,] ObstaclesLevel1 = new byte[,]
            {
                 {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                 {1,0,1,0,1,1,0,1,1,1,1,0,1,1,0,1,1,0,0,1,1,1,0,1},
                 {1,1,0,1,0,1,1,0,1,1,0,1,0,1,1,1,0,1,1,1,0,1,1,0},
                 {1,0,1,0,1,1,0,1,1,1,1,0,1,1,0,1,1,0,0,1,1,1,0,1},
                 {1,1,0,1,0,1,1,0,1,1,0,1,0,1,1,1,0,1,1,1,0,1,1,0},
                 {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1},
            };

            byte[,] PickablesLevel1 = new byte[,]
           {
                 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1},
                 {0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},

           };

            Level level1 = new Level(ObstaclesLevel1, PickablesLevel1, new List<Block>(), new List<Block>());
            level1.Create(Content);
            level1.NextLevel = AllLevels.Count + 1;
            AllLevels.Add(level1);

            // Level 2

            byte[,] ObstaclesLevel2 = new byte[,]
            {
                 {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                 {1,1,0,0,1,0,0,1,1,0,0,1,1,0,0,0,1,0,1,1,0,1,0,1},
                 {0,1,1,1,0,0,1,1,0,1,1,0,0,1,1,1,0,1,1,0,1,1,1,1},
                 {1,1,0,0,1,0,0,1,1,0,0,1,1,0,0,0,1,0,1,1,0,1,0,1},
                 {0,1,1,1,0,0,1,1,0,1,1,0,0,1,1,1,0,1,1,0,1,1,1,1},
                 {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1},
            };

            byte[,] PickablesLevel2 = new byte[,]
            {
                 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {0,2,0,0,3,0,0,2,0,0,0,0,2,0,0,0,3,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,2,0,0,0,0,0,0},
                 {0,3,2,0,0,0,3,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,2},
                 {2,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,2,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            };

            byte[,] EnemiesLevel2 = new byte[,]
             {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0},
            };

            HardLevel level2 = new HardLevel(ObstaclesLevel2, PickablesLevel2, EnemiesLevel2, new List<Block>(), new List<Block>(), new List<Tank>());
            level2.Create(Content);
            //level2.NextLevel = AllLevels.Count + 1;
            level2.NextLevel = 0; // Go back to first level
            AllLevels.Add(level2);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            clock.Update(gameTime);


            player.Update(gameTime);
            camera.Follow(player);
            AllLevels[CurrentLevel].Update(gameTime, Content);
            collisionManager.CheckCollision(player, AllLevels[CurrentLevel]);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(transformMatrix: camera.Transform);

            AllLevels[CurrentLevel].Draw(spriteBatch);
           
            player.Draw(spriteBatch);

            inventroyHelper.ShowInventroy(player, Content, spriteBatch);
            healtbar.ShowHealth(player, Content, spriteBatch);

            clock.ShowTime(Content, spriteBatch, player);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
