using System;
using _Project.Screpts.SOConfigs;
using _Project.Scripts.SOConfigs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Screen
{
    public abstract class BaseShopItem : MonoBehaviour
    {
        [SerializeField] protected ShopItems ShopItems;
        [SerializeField] protected PlayerWallet PlayerWallet;
        [SerializeField] protected Image ImageItems;
        [SerializeField] protected TextMeshProUGUI TextPrice;

        protected int Price;
        protected bool IsBuy = false;
        protected int ItemIndex;

        public event Action<int> OnBuyItem;

        public void SetData(int itemIndex, Sprite imageItems, int price, bool isBuy)
        {
            ItemIndex = itemIndex;
            IsBuy = isBuy;
            Price = price;
            if (isBuy)
            {
                ImageItems.sprite = imageItems;
                TextPrice.text = "USE";
            }
            else
            {
                ImageItems.sprite = imageItems;
                TextPrice.text = $"{price}";
            }
        }

        public virtual void BuyItem()
        {
            if (IsBuy)
            {
                OnBuyItem?.Invoke(ItemIndex);
                return;
            }

            if (PlayerWallet.PlayerValue >= Price)
            {
                PlayerWallet.RemoveValue(Price);
                OnBuyItem?.Invoke(ItemIndex);
                TextPrice.text = "USE";
            }
        }
    }
}