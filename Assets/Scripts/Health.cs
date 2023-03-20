using System;

public class Health
{
    public int Value { get; private set; }
    public int MaxValue { get; private set; }
    public float DamageCounter { get; private set; }
    public bool IsGonnaDie => DamageCounter >= MaxValue;

    public Health(int value)
    {
        Value = value;
        MaxValue = value;
    }

    public event Action Died;
    public void TakeDamage(int value)
    {
        Value -= value;

        if(Value <=0)
        {
            Value = 0;
            Died?.Invoke();
        }
    }

    public void AddDamage(float value)
    {
        DamageCounter+= value;
    }
}
