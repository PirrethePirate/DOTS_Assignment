using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


public partial struct SpawnerSystem : ISystem
{
    private Random random;

    public void OnCreate(ref SystemState state) 
    {
        random = new Random((uint)System.Environment.TickCount);
    }

    public void OnDestroy(ref SystemState state) { }

    public void OnUpdate(ref SystemState state) 
    {
        foreach(RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            if(spawner.ValueRO.NextSpawnTime < SystemAPI.Time.ElapsedTime)
            {
                for (int i = 0; i < spawner.ValueRW.EnemiesPerWave; i++)
                {
                    Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);
                    float randomX = random.NextFloat(-8f, 8f);
                    float randomY = random.NextFloat(0f, 2f);
                    float3 pos = new float3(randomX, spawner.ValueRO.SpawnPosition.y + randomY, 0);
                    state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(pos));
                }
                spawner.ValueRW.NextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO.SpawnRate;
            }
        }
    }

}
