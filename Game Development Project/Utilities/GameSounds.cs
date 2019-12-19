using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class GameSounds
    {
        static public SoundEffect PickSound { get; set; }
        static public SoundEffect HitSound { get; set; }
        static public SoundEffect DrinkSound { get; set; }
        static public SoundEffect JumpSound { get; set; }
        static public SoundEffect GameOverSound { get; set; }

        public GameSounds(SoundEffect pickupSound, SoundEffect hitSound, SoundEffect drinkSound, SoundEffect jumpSound, SoundEffect gameOverSound)
        {
            PickSound = pickupSound;
            HitSound = hitSound;
            DrinkSound = drinkSound;
            JumpSound = jumpSound;
            GameOverSound = gameOverSound;
        }

        static public void PlayHitSound()
        {
            HitSound.Play();
        }

        static public void PlayDrinkSound()
        {
            DrinkSound.Play();
        }
        static public void PlayPickSound()
        {
            PickSound.Play();
        }

        static public void PlayGameOverSound()
        {
            GameOverSound.Play();
        }

        static public void PlayJumpSound()
        {
            JumpSound.Play();
        }

    }
}
