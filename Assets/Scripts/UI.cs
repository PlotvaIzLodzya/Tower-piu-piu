using System;
using UnityEngine;

public class UI: MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    [SerializeField] private HealthView _healthView;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private UpgradeSystemView _upgradeSystenView;

    private Economy _economy;

    public void Init(Economy economy, Tower tower)
    {
        _gameOverScreen.Disable();
        _economy = economy;
        _walletView.Init(economy);
        _healthView.Init(tower.Health);
        _upgradeSystenView.Init(tower.Upgrades, _economy);
    }

    public void SetGameOverScreen()
    {
        _gameOverScreen.Enable();
    }

    public void SetWinScreen()
    {
        _winScreen.Enable();
    }
}
