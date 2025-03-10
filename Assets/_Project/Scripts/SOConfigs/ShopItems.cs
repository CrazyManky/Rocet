using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.SOConfigs
{
    [CreateAssetMenu(fileName = "ShopElements", menuName = "ShopElements")]
    public class ShopItems : ScriptableObject
    {
        [SerializeField] private List<BackgroundItem> _backgrounds = new();
        [SerializeField] private List<ShipItem> _shipsPlayer = new();
        [SerializeField] private List<BuffShopItem> _buffItems = new();

        public Sprite ActiveBackground;
        public Sprite ActiveShip;
        public BuffShopItem ActiveBuff = null;

        public List<BackgroundItem> GetBackgroundItems()
        {
            _backgrounds.ForEach((item) => { item.LoadData(); });
            return _backgrounds;
        }

        public List<ShipItem> GetShipsItems()
        {
            _shipsPlayer.ForEach((item) => { item.LoadData(); });
            return _shipsPlayer;
        }

        public List<BuffShopItem> GetBuffs()
        {
            _buffItems.ForEach((item) => { item.LoadData(); });
            return _buffItems;
        }

        public void SetNewBackground(int itemIndex)
        {
            _backgrounds[itemIndex].Unlock(true);
            ActiveBackground = _backgrounds[itemIndex].BackgroundSprite;
        }

        public void SetNewShip(int itemIndex)
        {
            _shipsPlayer[itemIndex].Unlock(true);
            ActiveShip = _shipsPlayer[itemIndex].GameSprite;
        }

        public void SetNewBuff(int itemIndex)
        {
            _buffItems[itemIndex].Unlock(true);
            ActiveBuff = _buffItems[itemIndex];
        }
    }

    [Serializable]
    public class BackgroundItem
    {
        public int ID;
        public Sprite ShopSprite;
        public Sprite BackgroundSprite;
        public bool IsUnlock;
        public int Price;

        public void LoadData()
        {
            var value = PlayerPrefs.GetInt($"Item:{ID}", 0);
            if (value == 0)
                IsUnlock = false;
            else
                IsUnlock = true;
        }

        public void Unlock(bool value)
        {
            IsUnlock = value;
            PlayerPrefs.SetInt($"Item:{ID}", 1);
        }
    }

    [Serializable]
    public class ShipItem
    {
        public int ID;
        public Sprite ShopSprite;
        public Sprite GameSprite;
        public bool IsUnlock;
        public int Price;

        public void LoadData()
        {
            var value = PlayerPrefs.GetInt($"ItemShip:{ID}", 0);
            if (value == 0)
                IsUnlock = false;
            else
                IsUnlock = true;
        }

        public void Unlock(bool value)
        {
            IsUnlock = value;
            PlayerPrefs.SetInt($"ItemShip:{ID}", 1);
        }
    }

    [Serializable]
    public class BuffShopItem
    {
        public int ID;
        public Sprite ShopSprite;
        public bool IsUnlock;
        public int Price;

        public void LoadData()
        {
            var value = PlayerPrefs.GetInt($"ItemBuff:{ID}", 0);
            if (value == 0)
                IsUnlock = false;
            else
                IsUnlock = true;
        }

        public void Unlock(bool value)
        {
            IsUnlock = value;
            PlayerPrefs.SetInt($"ItemBuff:{ID}", 1);
        }
    }
}