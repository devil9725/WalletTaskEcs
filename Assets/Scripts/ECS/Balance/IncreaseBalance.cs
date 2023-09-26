using Unity.Entities;

public struct IncreaseBalance : IComponentData
{
    public Entity Target;
    public int Value;
}
