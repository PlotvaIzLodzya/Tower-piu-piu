using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(Level), menuName = "ScriptableObject/Levels")]
public class Level: ScriptableObject
{
    [SerializeField] private List<Wave> _waves;

    public int WaveCount => _waves.Count;

    public Wave GetWave(int index)
    {
        return _waves[index];
    }
}

