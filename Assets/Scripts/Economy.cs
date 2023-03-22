public class Economy
{
    private ValueHandler _wallet;
    private string SaveName = "Economy";

    public float WalletValue => _wallet.Value;

    public Economy(string towerGuid)
    {
        _wallet = new ValueHandler(0, 1000000f, $"{towerGuid}{SaveName}");
    }

    public void AddMoney(float value)
    {
        _wallet.Increase(value);
    }

    public bool TryTakeMoney(float value)
    {
        return _wallet.TryDecrease(value);
    }
}

