using System.Linq;
using UnityEngine;

public class UpgradeSystemView : MonoBehaviour
{
    [SerializeField] private UpgradeView _upgradeViewPrefab;
    [SerializeField] private UpgradeViewContainer _upgradeViewContainer;

    private UpgradeSystem _upgradeSystem;

    public void Init(UpgradeSystem upgradeSystem, Economy economy)
    {
        _upgradeSystem = upgradeSystem;

        foreach (var upgradable in _upgradeSystem.Upgrades)
        {
            var upgradeView = Instantiate(_upgradeViewPrefab, _upgradeViewContainer.transform);
            upgradeView.Init(upgradable.Data, economy);
        }
    }
}
