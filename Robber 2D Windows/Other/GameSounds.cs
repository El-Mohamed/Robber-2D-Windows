using Microsoft.Xna.Framework.Audio;

namespace Robber_2D_Windows
{
    class GameSounds
    {
        static public SoundEffect PickSound, HitSound, DrinkSound, JumpSound, GameOverSound;

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
