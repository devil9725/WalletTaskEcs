using Unity.Entities;
using UnityEngine;

public class BalanceAuthoring : MonoBehaviour
{
    class Baker : Baker<BalanceAuthoring>
    {
        public override void Bake(BalanceAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new BalanceData());
        }
    }
}
