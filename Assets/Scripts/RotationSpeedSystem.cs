using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;


public class RotationSpeedSystem : JobComponentSystem
{
    [BurstCompile]
    private struct RotationSpeedRotation : IJobProcessComponentData<Rotation, RotationSpeed>
    {
        public float Dt;

        public void Execute(ref Rotation rotation, [ReadOnly] ref RotationSpeed speed)
        {
            rotation.Value = math.mul(math.normalize(rotation.Value),
                quaternion.AxisAngle(math.up(), speed.Value * Dt));
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new RotationSpeedRotation() {Dt = Time.deltaTime};
        return job.Schedule(this, inputDeps);
    }
}