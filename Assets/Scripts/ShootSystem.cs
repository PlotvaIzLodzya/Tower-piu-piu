using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[Serializable]
public class ShootSystem
{
    private EnemyContainer _enemyContainer;
    private Transform _aimPoint;

    public Aim Aim { get; private set; }
    public Weapon Weapon { get; private set; }
    public AttackSpeed AttackSpeed { get; private set; }

    public UpgradeSystem Upgrades;

    public ShootSystem(Transform aimPoint, Projectile projectile, EnemyContainer enemyContainer, string guid)
    {
        _enemyContainer = enemyContainer;
        _aimPoint = aimPoint;
        Aim = new Aim(aimPoint, new Upgrade(UpgradeType.AttackRange, guid, 0.2f, 3f));
        Weapon = new Weapon(aimPoint, new Upgrade(UpgradeType.Damage, guid, 1f, 100000f), projectile);
        AttackSpeed = new AttackSpeed(new Upgrade(UpgradeType.AttackSpeed, guid, 1f, 100f));

        Upgrades = new UpgradeSystem(new List<Upgradable>()
        {
            Aim,
            Weapon,
            AttackSpeed
        });
    }

    public IEnumerator Aiming()
    {
        IDamagable damagable = null;

        while (true)
        {
            yield return new WaitUntil(() => _enemyContainer.TryGetClosestEnemy(_aimPoint.position, out damagable));
            yield return Shooting(damagable);
        }
    }

    private IEnumerator Shooting(IDamagable damagable)
    {
        while (damagable.Health.IsGonnaDie == false)
        {
            var direction = Aim.GetDirection(damagable.Transform.position);
            Weapon.Shoot(direction);
            damagable.Health.AddDamage(Weapon.Damage);

            yield return new WaitForSeconds(AttackSpeed.Data.Value);
        }
    }
}
