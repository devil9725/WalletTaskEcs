using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Counter.UI
{
    public class BalanceCheatView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _caption;
        [SerializeField] private Button _plus;
        [SerializeField] private Button _clear;

        public Action onPlusClick;
        public Action onClearClick;

        private void Start()
        {
            _plus.onClick.AddListener(OnPlusButtonClick);
            _clear.onClick.AddListener(OnClearButtonClick);
        }

        public void SetCurrency(string caption)
        {
            _caption.text = caption;
        }

        public void OnPlusButtonClick()
        {
            onPlusClick?.Invoke();
        }

        public void OnClearButtonClick()
        {
            onClearClick?.Invoke();
        }
    }
}