using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton: MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private CostView _cost;

    private Economy _economy;
    private Upgrade _upgrade;

    public void Init(Economy economy, Upgrade upgrade)
    {
        _upgrade = upgrade;
        _economy = economy;
        _cost.UpdateInfo(_upgrade.CurrentCost);  
        _button.onClick.AddListener(Buy);
    }

    private void Buy()
    {
        if (_economy.TryTakeMoney(_upgrade.CurrentCost) && _upgrade.IsMaxed == false)
        {
            Upgrade();
        }
    }

    private void Upgrade()
    {
        _upgrade.LvlUp();
    }
}
