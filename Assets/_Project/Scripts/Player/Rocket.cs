using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Player
{
    public class Rocket : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private RectTransform _rect;
        [SerializeField] private float _dureation;
        [SerializeField] private float _snakePower;
        [SerializeField] private int _vibration;

        public void Init(Sprite shipSprite)
        {
            _image.sprite = shipSprite;
            _rect.DOShakePosition(_dureation, _snakePower, _vibration).SetLoops(-1, LoopType.Restart);
        }
    }
}