using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour, IDamagable
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private TriggerZone _triggerZone;
    [SerializeField] private UpgradeDatas _upgradeDatas = new UpgradeDatas();

    [field: SerializeField] private GUIDObject _gUIDObject = new GUIDObject();

    private ShootSystem _shootSystem;

    public Health Health { get; private set; }
    public Fraction Fraction { get; private set; } = Fraction.Player;
    public UpgradeSystem Upgrades { get; private set; }
    public Transform Transform => transform;
    public string GUID => _gUIDObject.GUID;
    public bool IsVisible { get; private set; } = true;

    public event Action<IDamagable> Died;

    public void Init(EnemyContainer enemyContainer)
    {
        Upgrades = new UpgradeSystem(_upgradeDatas);
        Health = new Health(1);
        _triggerZone.Init(enemyContainer, Fraction);
        _shootSystem = new ShootSystem(_triggerZone, _projectilePrefab, transform, enemyContainer, Upgrades, _gUIDObject.GUID);
        StartCoroutine(_shootSystem.Aiming(Fraction));
    }

    private void OnEnable()
    {
        Health.Died += Die;
    }

    private void OnDisable()
    {
        Health.Died -= Die;
    }

    [ContextMenu("Regenerate GUID")]
    private void GenerateGUID()
    {
        _gUIDObject.RegenerateGUID();
    }

    public void TakeDamage(int value)
    {
        Health.TakeDamage(value);
    }

    public void Die()
    {
        Died?.Invoke(this);
        _shootSystem.Stop();
        Destroy(gameObject);
    }
}
