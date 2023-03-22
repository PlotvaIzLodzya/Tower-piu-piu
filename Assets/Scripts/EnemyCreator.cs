using System.Collections;
using UnityEngine;

public class EnemyCreator
{
    public float ElapsedTime { get; private set; }
    private Transform _enemyContainer;
    private PositionRandomizer _positionRandomizer;
    private bool _isStop;

    public EnemyCreator(Transform enemyContainer)
    {
        _enemyContainer = enemyContainer;
        _positionRandomizer = new PositionRandomizer();
    }

    public void Stop()
    {
        _isStop = true;
    }

    public IEnumerator CreatingWave(Wave wave, IDamagable target)
    {
        int counter = 0;
        float delayTime = wave.DelayBetweenEnemies;

        while(ElapsedTime < wave.Duration && _isStop == false)
        {
            ElapsedTime += Time.deltaTime;
            delayTime+= Time.deltaTime;

            if (counter < wave.EnemyCount && delayTime>=wave.DelayBetweenEnemies)
            {
                Vector3 position = _positionRandomizer.GetRandomPosition(1.5f, 3f);
                Enemy enemy = Object.Instantiate(wave.GetEnemy(counter), position, Quaternion.identity );
                enemy.transform.SetParent(_enemyContainer);
                enemy.Init(target.Transform, wave.Reward);
                counter++;
                delayTime = 0;
            }

            yield return null;
        }

        ElapsedTime = 0f;
    }
}

