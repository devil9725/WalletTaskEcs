using Unity.Entities;

namespace Counter.UI
{
    class CurrencyCheat
    {
        private EntityManager _entityManager;
        private Entity _targetEntity;
        private BalanceCheatView _balanceCheatView;

        public CurrencyCheat(EntityManager entityManager, Entity targetEntity, BalanceCheatView balanceCheatView)
        {
            _entityManager = entityManager;
            _targetEntity = targetEntity;
            _balanceCheatView = balanceCheatView;
            _balanceCheatView.onClearClick += OnClearButtonClick;
            _balanceCheatView.onPlusClick += OnPlusButtonClick;
        }

        private void OnClearButtonClick()
        {
            var entity = _entityManager.CreateEntity(typeof(ResetBalance));
            _entityManager.AddComponentData(entity, new ResetBalance() { Target = _targetEntity });
        }

        private void OnPlusButtonClick()
        {
            var entity = _entityManager.CreateEntity(typeof(IncreaseBalance));
            _entityManager.AddComponentData(entity, new IncreaseBalance() { Target = _targetEntity, Value = 1 });
        }
    }
}