using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UpgradeSystem
{
    private List<Upgradable> _upgrades;

    public UpgradeSystem(List<Upgradable> upgradables)
    {
        _upgrades = upgradables;
    }

    public bool TryUpgrade(float value, UpgradeType upgradeType)
    {
        if(TryGetUpgradeData(upgradeType, out Upgrade towerUpgradeData))
        {
            towerUpgradeData.AddValue(value);

            return true;
        }

        return false;
    }
    
    public bool TryGetUpgradeData(UpgradeType upgradeType, out Upgrade towerUpgradeData)
    {
        towerUpgradeData = _upgrades.FirstOrDefault(upgrade => upgrade.Data.Type == upgradeType).Data;

        return towerUpgradeData != null;
    }
}
