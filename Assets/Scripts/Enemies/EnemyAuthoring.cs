using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class EnemyAuthoring : MonoBehaviour
{

    public float movementSpeed;

    class EnemyAuthoringBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            Entity enemyEntity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(enemyEntity, new EnemyMoveSpeed { Value = authoring.movementSpeed});
        }
    }
}

public struct EnemyTag : IComponentData { }

public struct EnemyMoveSpeed : IComponentData
{
    public float Value;
}
