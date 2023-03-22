using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;

    private EnemyContainer _enemyContainer;
    private Fraction _fraction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable enemy) && _fraction!= enemy.Fraction)
        {
            _enemyContainer.Add(enemy);
        }
    }

    public void Init(EnemyContainer enemyContainer, Fraction fraction)
    {
        _enemyContainer = enemyContainer;
        _fraction = fraction;
    }

    public void IncreaseRange(float value)
    {
        _rectTransform.localScale += new Vector3(value, value, 0);
    }
}
