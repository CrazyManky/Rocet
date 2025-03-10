using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BuffView : MonoBehaviour
{
    [SerializeField] private Image _imageBuff;
    [SerializeField] private Slider _slider;

    public void SetData(Sprite spriteBuff)
    {
        _imageBuff.sprite = spriteBuff;
        gameObject.SetActive(true);
        _slider.maxValue = 1;
        _slider.value = 1;
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        var waitForSecondsRealTime = new WaitForSecondsRealtime(0.1f);
        while (_slider.value > 0)
        {
            _slider.value -= 0.1f;
            yield return waitForSecondsRealTime;
        }

        Disable();
    }

    public void Disable() => gameObject.SetActive(false);
}