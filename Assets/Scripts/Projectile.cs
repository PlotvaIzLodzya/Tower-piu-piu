using System.Collections;
using UnityEngine;

public class Projectile: MonoBehaviour
{
    public int Damage { get; private set; }
    public float Speed { get; private set; }
    private Fraction _fraction;

    public void Init(float damage, float speed, Vector3 direction, Fraction fraction)
    {
        Damage = (int)damage;
        _fraction = fraction;
        Speed = speed;
        StartCoroutine(Flying(speed, direction));
        StartCoroutine(SelfDestruct(20f));
    }

    private IEnumerator Flying(float speed, Vector3 direction)
    {
        while (true)
        {
            transform.position += direction * speed * Time.deltaTime;

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable) && _fraction != damagable.Fraction)
        {
            damagable.TakeDamage(Damage);
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private IEnumerator SelfDestruct(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy();
    }
}
