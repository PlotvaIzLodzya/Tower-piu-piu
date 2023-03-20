using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private TriggerZone _triggerZone;

    [field: SerializeField] private GUIDObject _gUIDObject = new GUIDObject();

    private ShootSystem _shootSystem;

    private void Awake()
    {
        EnemyContainer enemyContainer = new EnemyContainer();
        _triggerZone.Init(enemyContainer);
        _shootSystem = new ShootSystem(transform, _projectilePrefab, enemyContainer, _gUIDObject.GUID);
        StartCoroutine(_shootSystem.Aiming());
    }

    [ContextMenu("Regenerate GUID")]
    private void GenerateGUID()
    {
        _gUIDObject.RegenerateGUID();
    }
}
