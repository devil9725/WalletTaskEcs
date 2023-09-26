using Unity.Entities;
using UnityEngine;

public class CoinsAuthoring : MonoBehaviour
{
    class Convert : Baker<CoinsAuthoring>
    {
        public override void Bake(CoinsAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new CoinsTag());
        }
    }
}
