using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;

    [field: SerializeField] private GUIDObject _gUIDObject = new GUIDObject();

    private ShootSystem _shootSystem;

    private void Awake()
    {
        _shootSystem = new ShootSystem(transform, _projectilePrefab, _gUIDObject.GUID);
    }

    private void Update()
    {
        //_shootSystem.Update();
    }

    [ContextMenu("Regenerate GUID")]
    private void GenerateGUID()
    {
        _gUIDObject.RegenerateGUID();
    }
}
