using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(Wave), menuName = "ScriptableObject/Wave")]
public class Wave : ScriptableObject
{
    [SerializeField] private List<Enemy> _enemies;
    [field: SerializeField] public float DelayBetweenEnemies { get; private set;}
    [field: SerializeField] public float Duration { get; private set;}
    [field: SerializeField] public Reward Reward { get; private set;}

    public int EnemyCount => _enemies.Count;

    public Enemy GetEnemy(int index)
    {
        return _enemies[index];
    }
}
