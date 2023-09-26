using Unity.Entities;

namespace Counter.Ecs
{
    public partial class UpdateBalanceSystem : SystemBase
    {

        protected override void OnUpdate()
        {
            var ecb = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);

            Entities.ForEach((Entity entity, int entityInQueryIndex, in IncreaseBalance increase) =>
            {
                if (SystemAPI.HasComponent<BalanceData>(increase.Target))
                {
                    var balance = SystemAPI.GetComponent<BalanceData>(increase.Target);
                    balance.Value += increase.Value;
                    ecb.SetComponent(increase.Target, balance);
                    ecb.DestroyEntity(entity);
                    ecb.AddComponent<UpdateUITag>(increase.Target);
                    ecb.AddComponent<DirtyTag>(increase.Target);
                }
            }).Schedule();

            Entities.ForEach((Entity entity, int entityInQueryIndex, in ResetBalance reset) =>
            {
                if (SystemAPI.HasComponent<BalanceData>(reset.Target))
                {
                    var balance = SystemAPI.GetComponent<BalanceData>(reset.Target);
                    balance.Value = 0;
                    ecb.SetComponent(reset.Target, balance);
                    ecb.DestroyEntity(entity);
                    ecb.AddComponent<UpdateUITag>(reset.Target);
                    ecb.AddComponent<DirtyTag>(reset.Target);
                }
            }).Schedule();
        }
    }
}