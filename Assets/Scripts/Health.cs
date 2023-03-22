using System;

public class Health
{
    public int Value { get; private set; }
    public int MaxValue { get; private set; }
    public float DamageCounter { get; private set; }
    public bool IsGonnaDie => DamageCounter >= MaxValue;
    public bool IsDead { get; private set; }

    public event Action Died;

    public Health(int maxHealth)
    {
        Value = maxHealth;
        MaxValue = maxHealth;
    }

    public Health(int current, int max)
    {
        Value = current;
        MaxValue = max;
    }

    public void TakeDamage(int value)
    {
        Value -= value;

        if(Value <=0)
        {
            Value = 0;
            IsDead = true;
            Died?.Invoke();
        }
    }

    public void AddDamage(float value)
    {
        DamageCounter+= value;
    }
}
