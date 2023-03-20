using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private EnemyContainer _enemyContainer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable enemy))
        {
            _enemyContainer.Add(enemy);
        }
    }

    public void Init(EnemyContainer enemyContainer)
    {
        _enemyContainer = enemyContainer;
    }
}
