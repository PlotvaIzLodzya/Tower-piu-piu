using System;
using UnityEngine;

[Serializable]
public struct Reward
{
    [SerializeField] private int DefaultValue;
    [SerializeField] private int WaveMultiplier;

    public int EnemyMultiplier;
    public int Value => DefaultValue * WaveMultiplier * EnemyMultiplier;
}
