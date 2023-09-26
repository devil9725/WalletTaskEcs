using Counter.Ecs;
using Unity.Entities;
using UnityEngine;

namespace Counter.UI
{
    public class CurrencyCheatUI : MonoBehaviour
    {
        [SerializeField] private BalanceCheatView _balanceCheatViewPrefab;
        private EntityManager _entityManager;

        private void Awake()
        {
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        private void OnEnable()
        {
            var showCurrencyUISystem = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<ShowCurrencyUISystem>();
            showCurrencyUISystem.OnLoadCurrency += LoadCurrency;
        }

        private void OnDisable()
        {
            if (World.DefaultGameObjectInjectionWorld == null)
                return;
            var showCurrencyUISystem = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<ShowCurrencyUISystem>();
            showCurrencyUISystem.OnLoadCurrency -= LoadCurrency;
        }

        private void LoadCurrency(Entity entity)
        {
            var balanceCheatView = Instantiate(_balanceCheatViewPrefab, transform);
            var currencyCounterData = _entityManager.GetComponentData<CurrencyCounterData>(entity);
            balanceCheatView.SetCurrency(currencyCounterData.Name.ToString());
            new CurrencyCheat(_entityManager, entity, balanceCheatView);
        }
    }
}