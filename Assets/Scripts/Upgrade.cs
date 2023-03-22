using System;
using System.Diagnostics;

public class Upgrade
{
    private ValueHandler _lvl;
    public UpgradeType Type { get; private set; }
    public UpgradeData Data { get; private set; }
    public int CurrentLvl => (int)_lvl.Value;
    public int CurrentCost => Data.GetData(CurrentLvl+1).Cost;
    public float NextValue => Data.GetData(CurrentLvl+1).Value;
    public float Value { get; private set; }
    public float MaxValue => Data.MaxLevel;
    public bool IsMaxed => CurrentLvl >= Data.MaxLevel;

    public event Action ValueChanged;

    public Upgrade(UpgradeData upgradeData, string guid)
    {
        Type = upgradeData.Type;
        Data= upgradeData;
        _lvl = new ValueHandler(0, upgradeData.MaxLevel, $"{guid}{Type.ToString()}");
        Value = Data.GetData((int)_lvl.Value).Value;
    }

    public void LvlUp()
    {
        _lvl.Increase(1);
        Value = Data.GetData((int)_lvl.Value).Value;
        ValueChanged?.Invoke();
    }
}
