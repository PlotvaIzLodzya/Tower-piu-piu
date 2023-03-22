using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private int _enemyCostMultiplier;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    [field:SerializeField] public EnemyView View { get; private set; }

    private Movement _movement = new Movement();

    public Transform Transform => transform;
    public Fraction Fraction { get; private set; } = Fraction.Enemy; 
    public Health Health { get; private set; } = new Health(3);
    public bool IsVisible => View.IsVisible;

    private Reward Reward;
    public int RewardValue => Reward.Value;

    public event Action<IDamagable> Died;

    private void OnEnable()
    {
        Health.Died += Die;
    }

    private void OnDisable()
    {
        Health.Died -= Die;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IDamagable damagable) && damagable.Fraction != Fraction)
        {
            damagable.TakeDamage(_damage);
            Die();
        }
    }

    public void Init(Transform point, Reward reward)
    {
        View.Init();
        Reward = reward;
        Reward.EnemyMultiplier = _enemyCostMultiplier;
        MoveTo(point, _speed);
    }

    public void MoveTo(Transform point, float speed)
    {
        _movement.Move(transform, point, speed);
    }

    public void TakeDamage(int value)
    {
        Health.TakeDamage(value);
    }

    private void Die()
    {
        Died?.Invoke(this);
        _movement.Stop();
        StartCoroutine(DelayingDestroy());
    }

    private IEnumerator DelayingDestroy()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
