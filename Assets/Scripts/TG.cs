using System;
using Unity.Entities;
using UnityEngine;


/// <summary>
/// 使用ISharedComponentData可显著降低内存
/// </summary>
[Serializable]
public struct SpawnRandomCircle : ISharedComponentData //使用ISharedComponentData可显著降低内存
{
    //预制方块
    public GameObject prefab;

    public bool spawnLocal;

    //生成的半径
    public float radius;

    //生成物体个数
    public int count;
}

/// <summary>
/// 包含方块的个数个生成半径等
/// </summary>
public class SpawnRandomCircleComponent : SharedComponentDataWrapper<SpawnRandomCircle>
{
}