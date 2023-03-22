using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _upgradeStats;
    [SerializeField] private BuyButton _button;

    private Upgrade _upgrade;

    private void OnEnable()
    {
        if(_upgrade != null)
            _upgrade.ValueChanged += UpdateInfo;
    }

    private void OnDisable()
    {
        _upgrade.ValueChanged -= UpdateInfo;
    }

    public void Init(Upgrade upgrade, Economy economy)
    {
        _upgrade = upgrade;
        _upgrade.ValueChanged += UpdateInfo;
        _button.Init(economy, upgrade);
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        _upgradeStats.text = $"{_upgrade.NextValue}";
    }
}
