using TMPro;
using UnityEngine;

public class HealthView: MonoBehaviour
{
    [SerializeField] private TMP_Text _healthView;

    private Health _health;

    public void Init(Health health)
    {
        _health = health;
    }

    private void Update()
    {
        _healthView.text = $"{_health.Value}/{_health.MaxValue}";

    }
}

