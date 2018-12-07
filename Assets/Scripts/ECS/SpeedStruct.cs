using UnityEngine;
using Unity.Entities;

namespace ECS
{
    public struct SpeedStruct : IComponentData
    {
        public Vector3 Speed;
    }

    // ComponentDataWrapper用于将ComponentData添加到GameObject，
    // 这一步需要手动添加，将来Unity会自动化这步操作。
    public class SpeedComponent : ComponentDataWrapper<SpeedStruct>
    {
    }
}