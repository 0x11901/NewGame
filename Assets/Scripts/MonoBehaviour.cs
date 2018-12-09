using Unity.Entities;
using UnityEngine;

/// <summary>
/// ComponentSystem管理游戏逻辑（类比以前的MonoBehavior）
/// 该类只有一个OnUpdate方法需要复写
/// </summary>
class RotatorSystem : ComponentSystem
{
    /// <summary>
    /// 简单的Group结构体，规定Entity必须包含哪些ComponentData
    /// </summary>
    private struct Group
    {
        public Transform Transform;
        public Test Rotator;
    }

    protected override void OnUpdate()
    {
        //遍历场景中同时包含transform和Rotator的Entity，执行操作
        foreach (var item in GetEntities<Group>())
        {
            item.Transform.rotation *= Quaternion.AngleAxis(item.Rotator.Speed * Time.deltaTime, Vector3.up);
        }
    }
}