using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer
{
    private List<Enemy> _enemys = new List<Enemy>();

    public event Action<Enemy> EnemyDied;

    public bool TryGetClosestEnemy(Vector3 position, out IDamagable damagable)
    {
        damagable = null;
        float minDistance = Mathf.Infinity;

        foreach (var enemy in _enemys)
        {
            float distance = Vector3.Distance(enemy.Transform.position, position);

            if (distance < minDistance && enemy.Health.IsGonnaDie == false)
            {
                damagable = enemy;
                minDistance = distance;
            }
        }

        return damagable != null;
    }

    public void Add(IDamagable enemy)
    {
        _enemys.Add(enemy as Enemy);
        enemy.Died += Remove;
    }

    public void Remove(IDamagable damagable)
    {
        damagable.Died -= Remove;
        Enemy enemy = damagable as Enemy;
        _enemys.Remove(enemy);
        EnemyDied?.Invoke(enemy);
    }
}
