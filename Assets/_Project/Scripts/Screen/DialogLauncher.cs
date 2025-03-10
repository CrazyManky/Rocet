using _Project.Screpts.Services;
using _Project.Scripts.Audio;
using Services;
using UnityEngine;

namespace _Project.Scripts.Screen
{
    public class DialogLauncher : MonoBehaviour, IService
    {
        [SerializeField] private MenuScreen _menuScreen;
        [SerializeField] private ShopScreen _shopScreen;
        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private RecordScreen _recordScreen;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private GamePlayScreen _gamePlayScreen;


        private BaseScreen _activeScreen;

        private void Awake()
        {
            ServiceLocator.Init();
            ServiceLocator.Instance.AddService(this);
            ServiceLocator.Instance.AddService(_audioManager);
            //ServiceLocator.Instance.AddService(PlayerWallet);
        }

        private void Start() => ShowMenuScreen();

        public void ShowMenuScreen()
        {
            _audioManager.PlayMenu();
            ShowScreen(_menuScreen);
        }

        public void ShowShopScreen() => ShowScreen(_shopScreen);

        public void ShowSettingsScreen() => ShowScreen(_settingsScreen);

        public void ShowRecordsScreen() => ShowScreen(_recordScreen);

        public void ShowGameScreen()
        {
            _audioManager.PlayGame();
            ShowScreen(_gamePlayScreen);
        }

        private void ShowScreen(BaseScreen screen)
        {
            _activeScreen?.Сlose();
            var instanceScreen = Instantiate(screen, transform);
            instanceScreen.Init();
            _activeScreen = instanceScreen;
        }
    }
}