using System;
using UnityEngine;

public interface IDamagable
{
    public Transform  Transform { get; }
    public Health Health { get; }
    public Fraction Fraction { get; }
    public bool IsDead => Health.IsDead;

    public event Action<IDamagable> Died;

    public void TakeDamage(int value);
}
