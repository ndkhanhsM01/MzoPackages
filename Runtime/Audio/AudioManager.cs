using System.Collections.Generic;
using UnityEngine;

namespace Mzo.Audio
{
    public class AudioManager : BaseSingleton<AudioManager>
    {
        public AudioSource audioMusic;
        public AudioSource audioSoundFX;

        [SerializeField] private AudioAsset resource;

        private Dictionary<AudioName, AudioEditing> soundsDictionary;

        protected override void Awake()
        {
            base.Awake();

            soundsDictionary = resource.GetDictionaryResource();
        }
        #region Music
        public void PlayBackgroundMusic(AudioName musicName)
        {
            if (soundsDictionary.ContainsKey(musicName))
            {
                AudioEditing music = soundsDictionary[musicName];
                audioMusic.clip = music.audioClip;
                audioMusic.Play();
                audioMusic.loop = true;
                audioMusic.volume = music.volume;
            }
        }
        #endregion

        #region Sound FX
        public void PlaySoundFX(AudioName name)
        {
            if (!soundsDictionary.ContainsKey(name)) return;

            AudioEditing fx = soundsDictionary[name];

            audioSoundFX.PlayOneShot(fx.audioClip, fx.volume);
        }
        #endregion
    }
}