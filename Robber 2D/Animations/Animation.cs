using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Robber_2D
{
    class Animation
    {
        List<AnimationFrame> allFrames;
        public AnimationFrame CurrentFrame;
        double xOffset;
        int counter = 0, refreshRate = 50;

        public Animation()
        {
            allFrames = new List<AnimationFrame>();
        }

        public void AddFrame(Rectangle rectangle)
        {
            AnimationFrame frame = new AnimationFrame()
            {
                SourceRectangle = rectangle
            };

            allFrames.Add(frame);
            CurrentFrame = allFrames[0];
        }

        public void Update(GameTime gameTime)
        {
            xOffset += CurrentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.Milliseconds;

            if (xOffset / refreshRate >= CurrentFrame.SourceRectangle.Width)
            {
                counter++;
                if (counter >= allFrames.Count)
                {
                    counter = 0;
                }

                CurrentFrame = allFrames[counter];
                xOffset = 0;
            }
        }

        public void IncreaseSpeed()
        {
            refreshRate--;
        }

        public void Freeze(int frameToFreeze)
        {
            CurrentFrame = allFrames[frameToFreeze];
        }
    }
}