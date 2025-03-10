using _Project.Screpts.SOConfigs;
using _Project.Scripts.Audio;
using Services;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Screen
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textScore;
        [SerializeField] private TextMeshProUGUI _scoreData;
        [SerializeField] private TextMeshProUGUI _playerWallerText;
        [SerializeField] private PlayerWallet _playerWallet;
        private DialogLauncher _dialogLauncher;
        private AudioManager _audioManager;

        public void Init(string value)
        {
            _scoreData.text = value;
            _playerWallerText.text = $"{_playerWallet.PlayerValue}";
            _dialogLauncher = ServiceLocator.Instance.GetService<DialogLauncher>();
            _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        }

        public void EnterGameScreen()
        {
            _audioManager.PlayButtonClick();
            _dialogLauncher.ShowGameScreen();
        }

        public void OpenMenu()
        {
            _audioManager.PlayButtonClick();
            _dialogLauncher.ShowMenuScreen();
        }
    }
}