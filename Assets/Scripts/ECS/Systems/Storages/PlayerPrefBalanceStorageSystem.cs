using Unity.Entities;
using UnityEngine;

namespace Counter.Ecs
{
    [UpdateBefore(typeof(ShowCurrencyUISystem))]
    public partial class PlayerPrefBalanceStorageSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<BalanceData>();
            RequireForUpdate<PrefsStorageData>();
        }

        protected override void OnUpdate()
        {
            var ecb = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);

            Entities.WithoutBurst().WithAll<LoadBalanceStorageTag>().ForEach((Entity entity, PrefsStorageData prefsBalanceComponent, BalanceData v) =>
            {
                var value = PlayerPrefs.GetInt(prefsBalanceComponent.Name.ToString(), 0);
                ecb.RemoveComponent<LoadBalanceStorageTag>(entity);
                EntityManager.SetComponentData(entity, new BalanceData() { Value = value });
            }).Run();

            Entities.WithoutBurst().WithAll<DirtyTag>().ForEach((Entity entity, PrefsStorageData prefsBalanceComponent, BalanceData v) =>
            {
                PlayerPrefs.SetInt(prefsBalanceComponent.Name.ToString(), v.Value);
                ecb.RemoveComponent<DirtyTag>(entity);
            }).Run();            
        }
    }
}