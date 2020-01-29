using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Robber_2D
{
    class SpecialWorld : World
    {
        public List<Tank> AllTanks;
        byte[,] EnemiesArray;
        int LastTimeShooted = 0;

        public SpecialWorld(byte[,] obstaclesArray, byte[,] pickablesArray, List<int> moneySafeIdentiefiers, byte[,] enemiesArray) : base(obstaclesArray, pickablesArray, moneySafeIdentiefiers)
        {
            AllTanks = new List<Tank>();
            EnemiesArray = enemiesArray;
        }

        private void CreateTanks(ContentManager contentManager)
        {

            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < LevelHeight; y++)
                {

                    Texture2D tempTexture = contentManager.Load<Texture2D>("Enemy1");
                    const int marginBottom = 1;
                    int maginLeft = (150 - tempTexture.Width) / 2;
                    float xPos = (x * 150) + maginLeft;
                    float yPos = (y * SpaceBetweenPlatforms) - tempTexture.Height - marginBottom;
                    Vector2 tempVector = Factory.CreateVector(xPos, yPos);
                    Rectangle tempCollisonRectangle = Factory.CreateRectangle((int)tempVector.X, (int)tempVector.Y, tempTexture.Width, tempTexture.Height);
                    Sprite tempSprite = Factory.CreateSprite(tempTexture, 1, tempVector);
                    Tank tempTank = WorldFactory.CreateTank(tempSprite, tempCollisonRectangle);

                    switch (EnemiesArray[y, x])
                    {
                        case 1:
                            tempTank.Direction = Direction.ToRight;
                            AllTanks.Add(tempTank);
                            break;
                        case 2:
                            tempTank.Direction = Direction.ToLeft;
                            AllTanks.Add(tempTank);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void DrawTanks(SpriteBatch spriteBatch)
        {
            foreach (Tank tank in AllTanks)
            {
                tank.Draw(spriteBatch);

                foreach (Bullet bullet in tank.ShootedBullets)
                {
                    bullet.Draw(spriteBatch);
                }
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawTanks(spriteBatch);
            base.Draw(spriteBatch);
        }

        public override void Create(ContentManager contentManager)
        {
            CreateTanks(contentManager);
            base.Create(contentManager);
        }

        public void CreateBullets()
        {
            if (LastTimeShooted >= 300)
            {
                foreach (Tank tank in AllTanks)
                {
                    tank.Shoot();
                }

                LastTimeShooted = 0;
            }
        }

        public override void Update(GameTime gameTime)
        {
            UpdateBullets(gameTime);
            LastTimeShooted += 100 * gameTime.ElapsedGameTime.Milliseconds / 500;
            base.Update(gameTime);
        }

        public void UpdateBullets(GameTime gameTime)
        {
            foreach (Tank tank in AllTanks)
            {
                foreach (Bullet bullet in tank.ShootedBullets)
                {
                    bullet.Update(gameTime);
                }
            }
        }
    }
}
