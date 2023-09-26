using Unity.Entities;
using UnityEngine;

public class PrefsStorageAuthoring : MonoBehaviour
{
    public string PrefName;
    class Baker : Baker<PrefsStorageAuthoring>
    {
        public override void Bake(PrefsStorageAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new PrefsStorageData() { Name = authoring.PrefName });
            AddComponent(entity, new LoadBalanceStorageTag());
        }
    }
}
