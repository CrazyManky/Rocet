using UnityEngine;

namespace _Project.Scripts.SOConfigs
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "SOConfigs/SoundConfig")]
    public class SoundConfig : ScriptableObject
    {
        [SerializeField] private bool _activeSound;
        [SerializeField] private bool _volumeMusic;

        public bool ActiveSound => _activeSound;
        public bool VolumeMusic => _volumeMusic;

        public void Load()
        {
            var valueSound = PlayerPrefs.GetInt("SoundVolume", 1);
            if (valueSound == 1)
                _activeSound = true;
            else
                _activeSound = false;

            var valueMusic = PlayerPrefs.GetInt("VolumeMusic", 1);
            if (valueMusic == 1)
                _volumeMusic = true;
            else
                _volumeMusic = false;
        }

        public void SetDataMusic(bool value)
        {
            if (value)
            {
                PlayerPrefs.SetInt("VolumeMusic", 1);
                _volumeMusic = true;
            }
            else
            {
                PlayerPrefs.SetInt("VolumeMusic", 0);
                _volumeMusic = false;
            }
        }

        public void SetDataSound(bool soundVolume)
        {
            if (soundVolume)
            {
                PlayerPrefs.SetInt("SoundVolume", 1);
                _activeSound = true;
            }
            else
            {
                PlayerPrefs.SetInt("SoundVolume", 0);
                _activeSound = false;
            }
        }
    }
}