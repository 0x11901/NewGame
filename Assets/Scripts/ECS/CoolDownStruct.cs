using Unity.Entities;

namespace ECS
{
    public struct CoolDownStruct : IComponentData
    {
        public float CoolDown;
        public float Margin;
    }

    public class CoolDownComponent : ComponentDataWrapper<CoolDownStruct>
    {
    }
}