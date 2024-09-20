using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;

[UpdateBefore(typeof(TransformSystemGroup))]

public partial struct EnemyMoveSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        new EnemyMoveJob
        {
            DeltaTime = deltaTime
        }.Schedule();
    }
}

public partial struct EnemyMoveJob : IJobEntity
{
    public float DeltaTime;

    [BurstCompile]
    private void Execute(ref LocalTransform transform, in EnemyMoveSpeed speed)
    {
        transform.Position.y -= speed.Value * DeltaTime;
    }

}

