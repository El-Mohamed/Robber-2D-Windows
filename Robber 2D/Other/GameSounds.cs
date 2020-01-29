using Microsoft.Xna.Framework.Audio;

namespace Robber_2D
{
    class GameSounds
    {
        static public SoundEffect PickSound, HitSound, DrinkSound, JumpSound, GameOverSound, ExplosionSound, ShootSound;

        public GameSounds(SoundEffect pickupSound, SoundEffect hitSound, SoundEffect drinkSound, SoundEffect jumpSound, SoundEffect gameOverSound, SoundEffect explosionSound, SoundEffect shootSound)
        {
            PickSound = pickupSound;
            HitSound = hitSound;
            DrinkSound = drinkSound;
            JumpSound = jumpSound;
            GameOverSound = gameOverSound;
            ExplosionSound = explosionSound;
            ShootSound = shootSound;
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

        static public void PlayExplosionSound()
        {
            ExplosionSound.Play();
        }

        static public void PlayShootSound()
        {
            ShootSound.Play();
        }
    }
}
