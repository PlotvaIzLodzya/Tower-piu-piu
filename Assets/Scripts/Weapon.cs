using UnityEngine;

public class Weapon : Upgradable
{
    private Projectile _projectile;
    private float _projectileSpeed;
    private Transform _projectileContainer;

    public float Damage => Data.Value;

    public Weapon(Transform pojectileContainer, Upgrade upgradeData, Projectile projectile) : base(upgradeData)
    {
        _projectile = projectile;
        _projectileContainer = pojectileContainer;
        _projectileSpeed = 1f;
    }

    public void Shoot(Vector3 direction)
    {
        var projectile = Object.Instantiate(_projectile, _projectileContainer);
        projectile.Init(Damage, _projectileSpeed, direction);
    }
}
