using System;
using System.Collections.Generic;
using _Project.Screpts.SOConfigs;
using _Project.Scripts.SOConfigs;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Screen
{
    public class ShopScreen : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI _textPlayerValue;
        [SerializeField] private PlayerWallet _playerWallet;
        [field: SerializeField] private BackgroundItemsHandler _backgroundItemsHandler;
        [field: SerializeField] private ShipsItemsShop _shipsItems;
        [field: SerializeField] private BuffsHandler _BuffsItems;

        public override void Init()
        {
            base.Init();
            _backgroundItemsHandler.Init();
            _shipsItems.Init();
            _BuffsItems.Init();
            _playerWallet.OnChange += SetData;
            SetData();
        }

        public void Update() => ResetBackground();

        private void SetData() => _textPlayerValue.text = $"{_playerWallet.PlayerValue}";

        public void BackMenu()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowMenuScreen();
        }

        public override void Сlose()
        {
            AudioManager.PlayButtonClick();
            _playerWallet.OnChange -= SetData;
            _shipsItems.Close();
            _BuffsItems.Close();
            _backgroundItemsHandler.Close();
            base.Сlose();
        }
    }

    [Serializable]
    public class BackgroundItemsHandler
    {
        [SerializeField] private ShopItems _shopItems;
        [SerializeField] private Transform _container;
        [SerializeField] private BaseShopItem _shopBackgroundPrefab;

        private List<BaseShopItem> _instanceItems = new();

        public void Init()
        {
            var shopItems = _shopItems.GetBackgroundItems();
            for (int i = 0; i < shopItems.Count; i++)
            {
                var shopItem = Object.Instantiate(_shopBackgroundPrefab, _container);
                shopItem.SetData(i, shopItems[i].ShopSprite, shopItems[i].Price, shopItems[i].IsUnlock);
                shopItem.OnBuyItem += SetNewBackground;
                _instanceItems.Add(shopItem);
            }
        }

        private void SetNewBackground(int itemIndex) => _shopItems.SetNewBackground(itemIndex);

        public void Close()
        {
            _instanceItems.ForEach((item) => { item.OnBuyItem -= SetNewBackground; });
            _instanceItems.Clear();
        }
    }

    [Serializable]
    public class ShipsItemsShop
    {
        [SerializeField] private ShopItems _shopItems;
        [SerializeField] private Transform _container;
        [SerializeField] private BaseShopItem _shopBackgroundPrefab;

        private List<BaseShopItem> _instanceItems = new();

        public void Init()
        {
            var shopItems = _shopItems.GetShipsItems();
            for (int i = 0; i < shopItems.Count; i++)
            {
                var shopItem = Object.Instantiate(_shopBackgroundPrefab, _container);
                shopItem.SetData(i, shopItems[i].ShopSprite, shopItems[i].Price, shopItems[i].IsUnlock);
                shopItem.OnBuyItem += _shopItems.SetNewShip;
                _instanceItems.Add(shopItem);
            }
        }

        public void Close()
        {
            _instanceItems.ForEach((item) => { item.OnBuyItem -= _shopItems.SetNewShip; });
            _instanceItems.Clear();
        }
    }

    [Serializable]
    public class BuffsHandler
    {
        [SerializeField] private ShopItems _shopItems;
        [SerializeField] private Transform _container;
        [SerializeField] private BaseShopItem _shopBackgroundPrefab;

        private List<BaseShopItem> _instanceItems = new();

        public void Init()
        {
            var shopItems = _shopItems.GetBuffs();
            for (int i = 0; i < shopItems.Count; i++)
            {
                var shopItem = Object.Instantiate(_shopBackgroundPrefab, _container);
                shopItem.SetData(i, shopItems[i].ShopSprite, shopItems[i].Price, shopItems[i].IsUnlock);
                shopItem.OnBuyItem += _shopItems.SetNewBuff;
                _instanceItems.Add(shopItem);
            }
        }

        public void Close()
        {
            _instanceItems.ForEach((item) => { item.OnBuyItem -= _shopItems.SetNewBuff; });
            _instanceItems.Clear();
        }
    }
}