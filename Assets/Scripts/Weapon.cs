using UnityEngine;

public class Weapon : Upgradable
{
    private Projectile _projectile;
    private float _projectileSpeed;

    public float Damage => Data.Value;

    public Weapon(Upgrade upgradeData, Projectile projectile) : base(upgradeData)
    {
        _projectile = projectile;
    }

    public void Shoot(Vector3 direction)
    {
        var projectile = Object.Instantiate(_projectile, direction, Quaternion.identity);
        projectile.Init(Damage, _projectileSpeed, direction);
    }
}
