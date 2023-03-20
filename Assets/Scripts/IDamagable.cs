using System;
using UnityEngine;

public interface IDamagable
{
    public Transform  Transform { get; }
    public Health Health { get; }

    public event Action<IDamagable> Died;

    public void TakeDamage(int value);
}
