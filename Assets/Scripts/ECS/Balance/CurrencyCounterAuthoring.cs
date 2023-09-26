using Unity.Entities;
using UnityEngine;

public class CurrencyCounterAuthoring : MonoBehaviour
{
    public string NameToShow;
    class Baker : Baker<CurrencyCounterAuthoring>
    {
        public override void Bake(CurrencyCounterAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new CurrencyCounterData() {Name = authoring.NameToShow });
            AddComponent(entity, new LoadUITag());
        }
    }
}