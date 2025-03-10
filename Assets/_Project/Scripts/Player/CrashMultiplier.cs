using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Player
{
    public class CrashMultiplier : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _textValue;
        [SerializeField] private float _growthRate = 0.1f; // Коэффициент роста
        [SerializeField] private float _minCrashTime = 2f;
        [SerializeField] private float _maxCrashTime = 20f;
        [SerializeField] private GamePlayScreen _gamePlayScreen;

        private float _multiplier;
        private float _crashTime;
        private bool _isRunning;

        public float Multiplier => _multiplier;

        public int LastWinMultiplier { get; private set; } 

        public void StartMultiplier()
        {
            if (_isRunning) return;

            _isRunning = true;
            _multiplier = 1f;
            _crashTime = GetRandomCrashTime();

            _slider.minValue = _minCrashTime;
            _slider.maxValue = _maxCrashTime;

            StartCoroutine(MultiplierRoutine());
        }

        private IEnumerator MultiplierRoutine()
        {
            float startTime = Time.time;

            while (_isRunning)
            {
                float elapsedTime = Time.time - startTime;
                _multiplier = 1f + _growthRate * elapsedTime * elapsedTime;
                _slider.value = elapsedTime;
                UpdateUI();

                if (elapsedTime >= _crashTime)
                    Crash();

                yield return null;
            }
        }

        public void StopMultiplier()
        {
            if (!_isRunning) return;

            _isRunning = false;
            LastWinMultiplier = Mathf.FloorToInt(_multiplier); // Округляем вниз
            Debug.Log($"Игрок забрал: x{LastWinMultiplier}");
        }

        private void Crash()
        {
            _isRunning = false;
            LastWinMultiplier = 0; // Если игрок не успел — выигрыш 0
            _gamePlayScreen.GameOver();
            Debug.Log("💥 КРАШ! Множитель сгорел!");
        }

        private float GetRandomCrashTime()
        {
            return Random.Range(_minCrashTime, _maxCrashTime);
        }

        private void UpdateUI()
        {
            _textValue.text = $"x{_multiplier.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}