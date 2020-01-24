using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Robber_2D_Windows
{
    class Animation
    {
        public List<AnimationFrame> allFrames;
        public AnimationFrame currentFrame;
        private double xOffset;
        int counter = 0;
        private int RefreshRate;

        public Animation()
        {
            allFrames = new List<AnimationFrame>();
            xOffset = 0;
            RefreshRate = 50;
        }

        public void AddFrame(Rectangle rectangle)
        {
            AnimationFrame frame = new AnimationFrame()
            {
                SourceRectangle = rectangle
            };

            allFrames.Add(frame);
            currentFrame = allFrames[0];
        }

        public void Update(GameTime gameTime)
        {
            xOffset += currentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.Milliseconds;
            if (xOffset/ RefreshRate >= currentFrame.SourceRectangle.Width)
            {
                counter++;
                if (counter >= allFrames.Count)
                {
                    counter = 0;
                }

                currentFrame = allFrames[counter];
                xOffset = 0;
            }
        }

        public void IncreaseSpeed()
        {
            RefreshRate -= 1;
        }

        public void Freeze(int frameToFreeze)
        {
            currentFrame = allFrames[frameToFreeze];
        }

    }
}