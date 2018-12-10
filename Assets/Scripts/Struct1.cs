using System;
using Unity.Entities;

/// <summary>
/// 一个简单的结构体（ComponentData）
/// </summary>
[Serializable]
public struct RotationSpeed : IComponentData
{
    public float value;
}

/// <summary>
/// 现阶段这个wrapper是为了能够把IComponentData添加给GameObject，
/// 将来会被移去
/// </summary>
public class RotationSpeedComponent : ComponentDataWrapper<RotationSpeed>
{
}