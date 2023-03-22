using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UpgradeSystem
{
    private List<Upgradable> _upgrades;
    private UpgradeDatas _upgradeDatas;
    public IReadOnlyList<Upgradable> Upgrades => _upgrades;

    public UpgradeSystem(UpgradeDatas upgradeDatas)
    {
        _upgrades = new List<Upgradable>();
        _upgradeDatas = upgradeDatas;
    }

    public void AddUpgrades(List<Upgradable> upgradables)
    {
        _upgrades.AddRange(upgradables);
    }

    public bool TryUpgrade(float value, UpgradeType upgradeType)
    {
        if(TryGetUpgrade(upgradeType, out Upgrade towerUpgrade))
        {
            towerUpgrade.LvlUp();

            return true;
        }

        return false;
    }

    public Upgradable GetUpgradable(UpgradeType type)
    {
        return _upgrades.First(upgrade => upgrade.Data.Type == type);
    }
    
    public bool TryGetUpgrade(UpgradeType upgradeType, out Upgrade towerUpgradeData)
    {
        towerUpgradeData = _upgrades.FirstOrDefault(upgrade => upgrade.Data.Type == upgradeType).Data;

        return towerUpgradeData != null;
    }

    public UpgradeData GetUpgradeData(UpgradeType type)
    {
        return _upgradeDatas.GetUpgradeData(type);
    }
}
