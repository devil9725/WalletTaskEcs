using Counter.Ecs;
using Unity.Entities;
using UnityEngine;

namespace Counter.UI
{
    public class CurrencyCounterUI : MonoBehaviour
    {
        [SerializeField] private CurrencyCounterView _counterTextViewPrefab;
        private EntityManager _entityManager;
        private CurrencyManager _currencyManager;

        private void Awake()
        {
            _currencyManager = new CurrencyManager(_counterTextViewPrefab,transform);
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        private void OnEnable()
        {
            var showCurrencyUI = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<ShowCurrencyUISystem>();
            showCurrencyUI.OnLoadCurrency += LoadCurrency;
            showCurrencyUI.OnUpdateCurrency += _currencyManager.Update;
        }

        private void OnDisable()
        {
            if (World.DefaultGameObjectInjectionWorld == null)
                return;
            var showCurrencyUI = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<ShowCurrencyUISystem>();
            showCurrencyUI.OnLoadCurrency -= LoadCurrency;
            showCurrencyUI.OnUpdateCurrency -= _currencyManager.Update;
        }

        private void LoadCurrency(Entity entity)
        {
            var currencyData = _entityManager.GetComponentData<CurrencyCounterData>(entity);
            var balanceData = _entityManager.GetComponentData<BalanceData>(entity);
            _currencyManager.AddCurrencyCounter(currencyData.Name.ToString());
            _currencyManager.Update(currencyData.Name.ToString(), balanceData.Value);
        }
    }
}