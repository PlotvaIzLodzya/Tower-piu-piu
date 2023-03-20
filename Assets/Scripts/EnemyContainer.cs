using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer
{
    private List<IDamagable> _enemys = new List<IDamagable>();

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
        _enemys.Add(enemy);
        enemy.Died += Remove;
    }

    public void Remove(IDamagable enemy)
    {
        enemy.Died -= Remove;
        _enemys.Remove(enemy);
    }
}
