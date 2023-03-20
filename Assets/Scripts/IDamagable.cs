using UnityEngine;

public interface IDamagable
{
    public Transform  Transform { get; }

    public void TakeDamage(float value);
}
