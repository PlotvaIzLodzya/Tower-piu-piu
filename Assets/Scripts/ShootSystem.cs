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
    private TriggerZone _triggerZone;

    public Aim AttackRange { get; private set; }
    public Weapon Weapon { get; private set; }
    public AttackSpeed AttackDelay { get; private set; }
    public UpgradeSystem Upgrades { get; private set; }

    public ShootSystem(TriggerZone triggerZone, Projectile projectile, Transform bulletContainer, EnemyContainer enemyContainer, UpgradeSystem upgradeSystem , string guid)
    {
        _enemyContainer = enemyContainer;
        _aimPoint = triggerZone.transform;
        Upgrades = upgradeSystem;
        _triggerZone = triggerZone;

        AttackRange = new Aim(triggerZone.transform, new Upgrade(Upgrades.GetUpgradeData(UpgradeType.AttackRange), guid));
        Weapon = new Weapon(bulletContainer, new Upgrade(Upgrades.GetUpgradeData(UpgradeType.Damage), guid), projectile);
        AttackDelay = new AttackSpeed(new Upgrade(Upgrades.GetUpgradeData(UpgradeType.AttackSpeed), guid));

        Upgrades.AddUpgrades(new List<Upgradable>()
        {
            AttackRange,
            Weapon,
            AttackDelay
        });

        AttackRange.Data.ValueChanged += IncreaseRange;
        IncreaseRange();
    }

    public void Stop()
    {
        AttackRange.Data.ValueChanged -= IncreaseRange;
    }

    public bool TryUpgrade(float value, UpgradeType type)
    {
        return Upgrades.TryUpgrade(value, type);
    }

    private void IncreaseRange()
    {
        _triggerZone.IncreaseRange(AttackRange.Data.Value);
    }

    public IEnumerator Aiming(Fraction fraction)
    {
        IDamagable damagable = null;

        while (true)
        {
            yield return new WaitUntil(() => _enemyContainer.TryGetClosestEnemy(_aimPoint.position, out damagable));
            yield return Shooting(damagable, fraction);
        }
    }

    private IEnumerator Shooting(IDamagable damagable, Fraction fraction)
    {
        while (damagable.Health.IsGonnaDie == false && damagable.IsDead ==false)
        {
            var direction = AttackRange.GetDirection(damagable.Transform.position);
            Weapon.Shoot(direction, fraction);
            damagable.Health.AddDamage(Weapon.Damage);

            yield return new WaitForSeconds(AttackDelay.Data.Value);

            if(_enemyContainer.TryGetClosestEnemy(_aimPoint.position, out damagable) == false)
                yield break;
        }
    }
}
