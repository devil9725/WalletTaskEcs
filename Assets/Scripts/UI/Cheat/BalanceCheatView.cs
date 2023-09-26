using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Counter.UI
{
    public class BalanceCheatView : MonoBehaviour
    {
        public Action OnPlusClick;
        public Action OnClearClick;

        [SerializeField] private TMP_Text _caption;
        [SerializeField] private Button _plus;
        [SerializeField] private Button _clear;

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
            OnPlusClick?.Invoke();
        }

        public void OnClearButtonClick()
        {
            OnClearClick?.Invoke();
        }
    }
}