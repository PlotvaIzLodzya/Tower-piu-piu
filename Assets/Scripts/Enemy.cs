using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public Transform Transform => transform;

    public Health Health { get; private set; } = new Health(3);

    public event Action<IDamagable> Died;

    private void OnEnable()
    {
        Health.Died += Die;
    }

    private void OnDisable()
    {
        Health.Died -= Die;
    }

    public void TakeDamage(int value)
    {
        Health.TakeDamage(value);
    }

    private void Die()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}
