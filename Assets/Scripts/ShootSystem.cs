using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShootSystem
{
    public Aim Aim { get; private set; }
    public Weapon Weapon { get; private set; }
    public AttackSpeed AttackSpeed { get; private set; }

    public UpgradeSystem Upgrades;

    public ShootSystem(Transform aimPoint, Projectile projectile, string guid)
    {
        Aim = new Aim(aimPoint, new Upgrade(UpgradeType.AttackRange, guid, 0.2f, 3f));
        Weapon = new Weapon(new Upgrade(UpgradeType.Damage, guid, 0f, 100000f), projectile);
        AttackSpeed = new AttackSpeed(new Upgrade(UpgradeType.AttackSpeed, guid, 1f, 100f));

        Upgrades = new UpgradeSystem(new List<Upgradable>()
        {
            Aim,
            Weapon,
            AttackSpeed
        });
    }

    public void Update(IDamagable enemy)
    {
    }
}
