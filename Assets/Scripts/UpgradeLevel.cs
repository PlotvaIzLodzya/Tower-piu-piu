using System;
using UnityEngine;

[Serializable]
public class UpgradeLevel
{
    [field: SerializeField] public int Cost { get; private set; }
    [field: SerializeField] public float Value { get; private set; }
}
