using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Counter.UI
{
    public class CurrencyManager
    {
        CurrencyCounterView _prefab;
        Transform _parent;
        private Dictionary<string, CurrencyCounterView> _currencyCounters = new Dictionary<string, CurrencyCounterView>();

        public CurrencyManager(CurrencyCounterView prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }

        public void AddCurrencyCounter(string key)
        {
            if (!_currencyCounters.ContainsKey(key))
            {
                var currencyCounterTextView = GameObject.Instantiate(_prefab, _parent);
                _currencyCounters[key] = currencyCounterTextView;
            }
        }

        public void Update(string key, int value)
        {
            _currencyCounters[key].SetValue(value);
        }
    }
}