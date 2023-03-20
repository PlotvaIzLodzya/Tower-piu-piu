using System;
using UnityEngine;

[Serializable]
public class Aim:Upgradable
{
    private Transform _aimPoint;

    public Aim(Transform aimPoint, Upgrade upgradeType) : base(upgradeType)
    {
        _aimPoint = aimPoint;
    }

    public Vector3 GetDirection(Vector3 enemyPosition)
    {
        return (enemyPosition- _aimPoint.position).normalized;
    }
}
