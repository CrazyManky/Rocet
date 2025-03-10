using _Project.Scripts.Audio;
using _Project.Scripts.SOConfigs;
using Services;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Project.Scripts.Screen
{
    public abstract class BaseScreen : MonoBehaviour
    {
        [SerializeField] protected Image Image;
        [SerializeField] protected ShopItems ShopItems;

        protected DialogLauncher Dialog;
        protected AudioManager AudioManager;

        public virtual void Init()
        {
            Image.sprite = ShopItems.ActiveBackground;
            Dialog = ServiceLocator.Instance.GetService<DialogLauncher>();
            AudioManager = ServiceLocator.Instance.GetService<AudioManager>();
        }

        public virtual void Сlose() => Destroy(gameObject);

        protected void ResetBackground()
        {
            Image.sprite = ShopItems.ActiveBackground;
        }
    }
}