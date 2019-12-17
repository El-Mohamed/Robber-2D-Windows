using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Development_Project
{
    class InGame : GameState
    {
        #region Fields
        public static Player player;

        public static int CurrentLevel;
        List<Level> AllLevels;
        CollisionManager collisionManager;

        InventoryBar inventroyHelper;
        HealthBar healtbar;

        GameSounds gameSounds;
        SpriteFont clockFont;
        SoundEffect pickSound, hitSound, drinkSound;
        Texture2D potionTexture, coinTexture, keyTexture, diamondTexture, healtTexture;

        #endregion

        public InGame(ContentManager contentManager, GraphicsDevice graphicsDevice, Game1 game) : base(contentManager, graphicsDevice, game)
        {
        
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.White);

            spriteBatch.Begin(transformMatrix: Camera2D.Transform);

            // Levels
            AllLevels[CurrentLevel].Draw(spriteBatch);

            // Player
            player.Draw(spriteBatch);

            // Clock
            Clock.Draw(spriteBatch);

            // Healtbar
            healtbar.Draw(spriteBatch);

            // Inventory
            inventroyHelper.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void Initialize()
        {
    
        }

        public override void LoadContent()
        {
            // Player 1

            int spriteSheetLength = 6;
            Texture2D playerTexture = contentManager.Load<Texture2D>("PlayerSpriteSheet");
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
            collisionManager = new CollisionManager();

            // SoundEffects
            pickSound = contentManager.Load<SoundEffect>("PickSound");
            hitSound = contentManager.Load<SoundEffect>("HitSound");
            drinkSound = contentManager.Load<SoundEffect>("DrinkSound");
            gameSounds = new GameSounds(pickSound, hitSound, drinkSound);


            // Clock

            clockFont = contentManager.Load<SpriteFont>("ClockFont");
            Clock.SpriteFont = clockFont;

            // Inventory Helper 

            keyTexture = contentManager.Load<Texture2D>("Pickable1");
            coinTexture = contentManager.Load<Texture2D>("Pickable2");
            potionTexture = contentManager.Load<Texture2D>("Pickable3");
            diamondTexture = contentManager.Load<Texture2D>("Diamond");
            inventroyHelper = new InventoryBar(player.Inventory, keyTexture, coinTexture, potionTexture, diamondTexture);

            // Healthbar

            healtTexture = contentManager.Load<Texture2D>("Health");
            healtbar = new HealthBar(healtTexture);

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
            level1.Create(contentManager);
            level1.NextLevel = 1; // Go to second level
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
            level2.Create(contentManager);
            level2.NextLevel = 0; // Go back to first level
            AllLevels.Add(level2);

        }

        public override void UnloadContent()
        {
     
        }

        public override void Update(GameTime gameTime)
        {
            // Player

            if(player.IsDead)
            {
                GameStateManager.Instance.SetCurrentState(new EndScreen(contentManager, graphicsDevice, game));
            }

            player.Update(gameTime);

            // Clock
            Clock.UpdateTime(gameTime);
            Clock.UpdatePosition(player);

            // Heathbar
            healtbar.UpdateHealth(player);
            healtbar.UpdatePosition(player);

            // Inventory
            inventroyHelper.UpdatePosition(player);

            // Camera
            Camera2D.Follow(player);

            // Levels
            AllLevels[CurrentLevel].Update(gameTime);
            collisionManager.CheckCollision(player, AllLevels[CurrentLevel]);
            if (AllLevels[CurrentLevel] is HardLevel)
            {
                HardLevel hardLevel = AllLevels[CurrentLevel] as HardLevel;
                hardLevel.CreateBullets(contentManager);
            }

        }
    }
}
