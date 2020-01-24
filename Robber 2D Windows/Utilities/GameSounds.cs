using Microsoft.Xna.Framework.Audio;

namespace Robber_2D_Windows
{
    class GameSounds
    {
        static public SoundEffect PickSound;
        static public SoundEffect HitSound;
        static public SoundEffect DrinkSound;
        static public SoundEffect JumpSound;
        static public SoundEffect GameOverSound;

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
