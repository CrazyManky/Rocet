using _Project.Scripts.SOConfigs;
using Project.Screpts.Screen;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Screen
{
    public class SettingsScreen : BaseScreen
    {
        [SerializeField] private SoundConfig _soundConfig;
        [SerializeField] private PolicyScreen _policyScreen;
        [SerializeField] private TextMeshProUGUI _textSoundActive;
        [SerializeField] private TextMeshProUGUI _textSoundDisable;
        [SerializeField] private TextMeshProUGUI _textMusicActive;
        [SerializeField] private TextMeshProUGUI _textMusicDisable;
        [SerializeField] private Color _colorActive;
        [SerializeField] private Color _colorDisable;

        private void Awake()
        {
            _soundConfig.Load();
            SwitchColorMusic(_soundConfig.VolumeMusic);
            SwitchColorSound(_soundConfig.ActiveSound);
            // _soundValue = _soundConfig.SoundActive;
        }

        public void DisableSound()
        {
            AudioManager.PlayButtonClick();
            SwitchColorSound(false);
            _soundConfig.SetDataSound(false);
        }

        public void ActiveSound()
        {
            AudioManager.PlayButtonClick();
            SwitchColorSound(true);
            _soundConfig.SetDataSound(true);
        }

        public void DisableMusic()
        {
            AudioManager.PlayButtonClick();
            SwitchColorMusic(false);
            _soundConfig.SetDataMusic(false);
        }

        public void ActiveMusic()
        {
            AudioManager.PlayButtonClick();
            SwitchColorMusic(true);
            _soundConfig.SetDataMusic(true);
        }

        public void ShowPrivacyPolicy()
        {
            AudioManager.PlayButtonClick();
            var instasncePrivacy = Instantiate(_policyScreen, transform);
            instasncePrivacy.Init();
        }


        public void BackMenu()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowMenuScreen();
        }

        private void SwitchColorSound(bool value)
        {
            if (value)
            {
                _textSoundDisable.color = _colorDisable;
                _textSoundActive.color = _colorActive;
            }
            else
            {
                _textSoundDisable.color = _colorActive;
                _textSoundActive.color = _colorDisable;
            }
        }

        private void SwitchColorMusic(bool value)
        {
            if (value)
            {
                _textMusicActive.color = _colorActive;
                _textMusicDisable.color = _colorDisable;
            }
            else
            {
                _textMusicActive.color = _colorDisable;
                _textMusicDisable.color = _colorActive;
            }
        }
    }
}