using Microsoft.Xna.Framework.Audio;

namespace Robber_2D
{
    static class GameSounds
    {
        static public SoundEffect PickSound, HitSound, DrinkSound, JumpSound, GameOverSound, ExplosionSound, ShootSound;

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
