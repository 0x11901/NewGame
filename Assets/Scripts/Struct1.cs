using Unity.Entities;
using System;

[Serializable]
public struct Struct1 : IComponentData
{
    public float Value;
}

public class Struct1Component : ComponentDataWrapper<Struct1>
{
}