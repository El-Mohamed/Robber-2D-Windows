using Microsoft.Xna.Framework.Audio;

namespace Robber_2D
{
    static class MenuSounds
    {
        public static SoundEffect SelectSound;

        static public void PlaySelectSound()
        {
            SelectSound.Play();
        }
    }
}
