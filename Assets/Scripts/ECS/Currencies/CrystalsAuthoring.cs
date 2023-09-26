using Unity.Entities;
using UnityEngine;

public class CrystalsAuthoring : MonoBehaviour
{
    class Baker : Baker<CrystalsAuthoring>
    {
        public override void Bake(CrystalsAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new CrystalsTag());
        }
    }
}
