using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class UpgradeDatas
{
    [SerializeField] private List<UpgradeData> _upgradeDatas;

    public UpgradeData GetUpgradeData(UpgradeType type)
    {
        return _upgradeDatas.First(data => data.Type == type);
    }
}
