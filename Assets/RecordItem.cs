using TMPro;
using UnityEngine;

public class RecordItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemIndex;
    [SerializeField] private TextMeshProUGUI _value;
    [SerializeField] private TextMeshProUGUI _multiplicate;

    public void SetData(int index, int playerValue, string multiplicate)
    {
        _itemIndex.text = $"{index + 1}";
        _value.text = $"{playerValue}";
        _multiplicate.text = multiplicate;
    }
    
}
