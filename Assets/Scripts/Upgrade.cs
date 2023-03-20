public class Upgrade
{
    private ValueHandler _valueHandler;
    public UpgradeType Type { get; private set; }
    public float Value => _valueHandler.Value;
    public float MaxValue => _valueHandler.MaxValue;
    public float MinValue => _valueHandler.MinValue;

    public Upgrade(UpgradeType type, string guid, float minValue, float maxValue)
    {
        Type = type;
        _valueHandler = new ValueHandler(minValue, maxValue, $"{guid}{Type.ToString()}");
    }

    public void AddValue(float value)
    {
        _valueHandler.Increase(value);
    }
}
