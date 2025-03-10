using System;
using System.Globalization;
using _Project.Screpts.SOConfigs;
using _Project.Scripts.Player;
using _Project.Scripts.Screen;
using _Project.Scripts.SOConfigs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScreen : BaseScreen
{
    [SerializeField] private RawImage _rawImage;
    [SerializeField] private TextMeshProUGUI _lastRecord;
    [SerializeField] private PlayerRecords _playerRecords;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Rocket _rocket;
    [SerializeField] private CrashMultiplier _crashMultiplier;
    [SerializeField] private TextMeshProUGUI _textValue;
    [SerializeField] private AsteroidsSpawnPoint _asteroidsSpawnPoint;
    [SerializeField] private BuffView _buffView;

    private float _offset = 0.1f;

    public override void Init()
    {
        base.Init();
        _rocket.Init(ShopItems.ActiveShip);
        _rawImage.texture = ShopItems.ActiveBackground.texture;
        _crashMultiplier.StartMultiplier();
        if (ShopItems.ActiveBuff.ShopSprite != null)
            _buffView.SetData(ShopItems.ActiveBuff.ShopSprite);
        else
            _buffView.Disable();


        _textValue.text = $"{_playerWallet.PlayerValue}";
        var value = _playerRecords.GetLastRecordItem();
        _lastRecord.text = $"{value.Multiplicate}";
        _asteroidsSpawnPoint.StartSpawning();
    }

    public void Update()
    {
        _rawImage.uvRect = new Rect(_rawImage.uvRect.x, _rawImage.uvRect.y + _offset * Time.deltaTime,
            _rawImage.uvRect.width, _rawImage.uvRect.height);
    }

    public void GameOver()
    {
        _crashMultiplier.StopMultiplier();
        _asteroidsSpawnPoint.StopSpawning();
        var instanceScreen = Instantiate(_gameOverScreen, transform);
        instanceScreen.Init("x0");
    }

    public void GameStop()
    {
        _crashMultiplier.StopMultiplier();
        _asteroidsSpawnPoint.StopSpawning();
        _playerWallet.AddValue(_crashMultiplier.LastWinMultiplier);
        var instanceScreen = Instantiate(_gameOverScreen, transform);
        var stringData = $"x{_crashMultiplier.Multiplier.ToString("F2", CultureInfo.InvariantCulture)}";
        _playerRecords.AddRecords(stringData, _playerWallet.PlayerValue);
        instanceScreen.Init(stringData);
    }

    public void BackToMenu()
    {
        AudioManager.PlayButtonClick();
        Dialog.ShowMenuScreen();
    }
}