using System;
using Unity.Entities;

namespace Counter.Ecs
{
    public partial class ShowCurrencyUISystem : SystemBase
    {
        public Action<Entity> OnLoadCurrency;
        public Action<string, int> OnUpdateCurrency;
        protected override void OnUpdate()
        {
            var ecb = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);

            Entities.WithoutBurst().WithAll<LoadUITag, CurrencyCounterData>().ForEach((Entity entity) =>
            {
                OnLoadCurrency?.Invoke(entity);
                ecb.RemoveComponent<LoadUITag>(entity);
            }).Run();

            Entities.WithoutBurst().WithAll<UpdateUITag, BalanceData>().ForEach((Entity entity, BalanceData balanceData, CurrencyCounterData counterData) =>
            {
                OnUpdateCurrency?.Invoke(counterData.Name.ToString(), balanceData.Value);
                ecb.RemoveComponent<UpdateUITag>(entity);
            }).Run();
        }
    }
}