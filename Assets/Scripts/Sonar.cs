using System.Collections;
using UnityEngine;

public class Sonar: MonoBehaviour
{
    [SerializeField] private SonarWave _sonarWavePrefab;

    private void Awake()
    {
        StartCoroutine(Waving());
    }

    private IEnumerator Waving()
    {
        float delay = 2f;

        while (true)
        {
            yield return new WaitForSeconds(delay);
            var wave = Instantiate(_sonarWavePrefab, transform);
            wave.Init();

        }
    }
}
