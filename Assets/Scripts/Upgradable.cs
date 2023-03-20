public class Upgradable
{
    public Upgrade Data { get; private set; }

    public Upgradable(Upgrade upgradeType)
    {
        Data = upgradeType;
    }
}
