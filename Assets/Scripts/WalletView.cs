using TMPro;
using UnityEngine;

public class WalletView: MonoBehaviour
{
    [SerializeField] private TMP_Text _wallet;

    private Economy _economy;

    public void Init(Economy economy)
    {
        _economy = economy;
    }

    private void Update()
    {
        _wallet.text = $"{_economy.WalletValue}";
    }
}
