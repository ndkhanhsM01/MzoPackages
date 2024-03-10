using System.Collections.Generic;
using UnityEngine;

namespace Mzo.Audio
{
    [CreateAssetMenu(fileName = "New Audio Asset", menuName = "Audio/Audio Asset")]
    public class AudioAsset : ScriptableObject
    {
        public List<AudioEditing> allSounds = new List<AudioEditing>();

        public Dictionary<AudioName, AudioEditing> GetDictionaryResource()
        {
            Dictionary<AudioName, AudioEditing> dictionarySounds = new Dictionary<AudioName, AudioEditing>();

            foreach (var sound in allSounds)
            {
                dictionarySounds.Add(sound.name, sound);
            }

            return dictionarySounds;
        }
    }

    [System.Serializable]
    public class AudioEditing
    {
        public AudioName name;
        [Range(0f, 1f)] public float volume = 1f;
        public AudioClip audioClip;
    }
}