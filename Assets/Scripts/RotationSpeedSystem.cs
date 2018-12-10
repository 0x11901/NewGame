using Unity.Burst;
using Unity.Entities;
using Unity.Jobs; //c# jobs
using Unity.Mathematics; //新的命名空间
using Unity.Transforms; //新的命名空间
using UnityEngine;

public class RotationSpeedSystem : JobComponentSystem
{
    /// <summary>
    /// 使用IJobProcessComponentData遍历符合条件的所有Entity。
    /// 此过程是单进程的并行计算（SIMD）
    /// IJobProcessComponentData 是遍历entity的简便方法，并且也比IJobParallelFor更高效
    /// </summary>
    [BurstCompile]
    private struct RotationSpeedRotation : IJobProcessComponentData<Rotation, RotationSpeed>
    {
        /// <summary>
        /// deltaTime
        /// </summary>
        public float Dt;

        /// <summary>
        /// 实现接口，在Excute中实现旋转
        /// </summary>
        public void Execute(ref Rotation rotation, ref RotationSpeed speed)
        {
            //读取speed，进行运算后，赋值给rotation
            rotation.Value = math.mul(math.normalize(rotation.Value), math.axisAngle(math.up(), speed.value * Dt));
        }
    }

    /// <summary>
    /// 我们在这里，只需要声明我们将要用到那些job
    /// JobComponentSystem 携带以前定义的所有job
    /// 最后别忘了返回jobs，因为别的job system 可能还要用
    /// 完全独立于主进程，没有等待时间！
    /// </summary>
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new RotationSpeedRotation() {Dt = Time.deltaTime};
        return job.Schedule(this, 64, inputDeps);
    }
}