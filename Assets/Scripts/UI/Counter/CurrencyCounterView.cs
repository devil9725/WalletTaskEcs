using TMPro;
using UnityEngine;

namespace Counter.UI
{
    public class CurrencyCounterView : MonoBehaviour
    {
        [SerializeField] TMP_Text _currencyText;
        [SerializeField] TMP_Text _valueText;
        public void SetCurrency(string currency)
        {
            _currencyText.text = $"{currency}:";
        }

        public void SetValue(int value)
        {
            _valueText.text = $"{value}";
        }
    }
}