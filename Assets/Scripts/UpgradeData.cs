using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Upgrade data", menuName = "ScriptableObject/Upgrade data")]
public class UpgradeData: ScriptableObject
{
    [SerializeField] private UpgradeLevel[] _upgradeLevels;
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public Color BackgroundColor { get; private set; }
    [field: SerializeField] public UpgradeType Type { get; private set; }

    public int MaxLevel => _upgradeLevels.Length;

    public UpgradeLevel GetData(int lvl)
    {
        if (lvl >= _upgradeLevels.Length)
            return _upgradeLevels[MaxLevel-1];

        return _upgradeLevels[lvl];
    }
}
