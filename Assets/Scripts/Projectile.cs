﻿using System.Collections;
using UnityEngine;

public class Projectile: MonoBehaviour
{
    public int Damage { get; private set; }
    public float Speed { get; private set; }

    public void Init(float damage, float speed, Vector3 direction)
    {
        Damage = (int)damage;
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
        if (collision.TryGetComponent(out IDamagable damagable))
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
