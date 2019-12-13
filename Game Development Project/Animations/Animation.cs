using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class Animation
    {
        public List<AnimationFrame> allFrames;
        public AnimationFrame currentFrame;
        private double xOffset;
        int counter = 0;

        public Animation()
        {
            allFrames = new List<AnimationFrame>();
            xOffset = 0;
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
            xOffset += currentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.Milliseconds / 50;
            if (xOffset >= currentFrame.SourceRectangle.Width)
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
    }
}