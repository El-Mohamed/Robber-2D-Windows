using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        public static int ScreenHeight, ScreenWidth, CurrentLevel;
        CollisionManager collisionManager;
        InventoryHelper inventroyHelper;
        Texture2D potionTexture, coinTexture, keyTexture, diamondTexture, healtTexture;
        Healtbar healtbar;
        GameSounds gameSounds;
        Clock clock;
        SpriteFont clockFont;
        SoundEffect pickSound, hitSound, drinkSound;

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
            Vector2 playerPosition = new Vector2();
            Vector2 playerSpeed = new Vector2(5, 4);
            Animation playerAnimation = new Animation();
            Sprite playerSprite = new Sprite(playerTexture, 6, playerPosition);
            Rectangle playerCollisonRectangle = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerTexture.Width / spriteSheetLength, playerTexture.Height);
            Inventory playerInventory = new Inventory();
            player = new Player(playerSprite, playerController, playerAnimation, playerCollisonRectangle, playerSpeed, playerInventory);
            player.Respawn();

            // Other

            AllLevels = new List<Level>();
            CurrentLevel = 0;
            camera = new Camera();
            collisionManager = new CollisionManager();

            // SoundEffects
            pickSound = Content.Load<SoundEffect>("PickSound");
            hitSound = Content.Load<SoundEffect>("HitSound");
            drinkSound = Content.Load<SoundEffect>("DrinkSound");
            gameSounds = new GameSounds(pickSound, hitSound, drinkSound);


            // Clock

            clockFont = Content.Load<SpriteFont>("ClockFont");
            clock = new Clock(clockFont);

            // Inventory Helper 

            keyTexture = Content.Load<Texture2D>("Pickable1");
            coinTexture = Content.Load<Texture2D>("Pickable2");
            potionTexture = Content.Load<Texture2D>("Pickable3");
            diamondTexture = Content.Load<Texture2D>("Diamond");
            inventroyHelper = new InventoryHelper(player.Inventory, keyTexture, coinTexture, potionTexture, diamondTexture);

            // Healthbar

            healtTexture = Content.Load<Texture2D>("Health");
            healtbar = new Healtbar(healtTexture);

            // Level 1&2 MoneySafe and Keys ID's

            List<int> MoneySafeIndetifiers = new List<int>() { 1000, 1001, 1002, 1003 };

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
                 {0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0},
                 {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            };

            Level level1 = new Level(ObstaclesLevel1, PickablesLevel1, MoneySafeIndetifiers, new List<Block>(), new List<Block>());
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
                 {0,0,0,0,0,4,0,0,0,2,0,0,0,0,0,4,0,2,0,0,0,0,0,0},
                 {0,3,2,0,0,0,3,0,4,0,0,0,0,0,2,0,0,0,0,0,0,0,0,2},
                 {2,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,2,0,0,0,4,0,0,0},
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

            HardLevel level2 = new HardLevel(ObstaclesLevel2, PickablesLevel2, MoneySafeIndetifiers, EnemiesLevel2, new List<Block>(), new List<Block>(), new List<Tank>());
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

            // Player
            player.Update(gameTime);

            // Clock
            clock.UpdateTime(gameTime);
            clock.UpdatePosition(player);

            // Heathbar
            healtbar.UpdateHealth(player);
            healtbar.UpdatePosition(player);

            // Inventory
            inventroyHelper.UpdatePosition(player);

            // Camera
            camera.Follow(player);

            // Levels
            AllLevels[CurrentLevel].Update(gameTime);
            collisionManager.CheckCollision(player, AllLevels[CurrentLevel]);
            if (AllLevels[CurrentLevel] is HardLevel)
            {
                HardLevel hardLevel = AllLevels[CurrentLevel] as HardLevel;
                hardLevel.CreateBullets(Content);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(transformMatrix: camera.Transform);

            // Levels
            AllLevels[CurrentLevel].Draw(spriteBatch);
           
            // Player
            player.Draw(spriteBatch);

            // Clock
            clock.Draw(spriteBatch);

            // Healtbar
            healtbar.Draw(spriteBatch);

            // Inventory
            inventroyHelper.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
