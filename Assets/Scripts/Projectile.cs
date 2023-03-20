using System.Collections;
using UnityEngine;

public class Projectile: MonoBehaviour
{
    public float Damage { get; private set; }
    public float Speed { get; private set; }

    public void Init(float damage, float speed, Vector3 direction)
    {
        Damage = damage;
        Speed = speed;
        StartCoroutine(Flying(speed, direction));
    }

    private IEnumerator Flying(float speed, Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction);

        while (true)
        {
            transform.position += direction * speed * Time.deltaTime;

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamagable damagable))
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
