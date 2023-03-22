using System.Collections;
using UnityEngine;

public class Game: MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private Level _level;
    [SerializeField] private Transform _enemyTransformContainer;
    [SerializeField] private UI _ui;

    private EnemyCreator _enemyCreator;
    private Economy _economy;
    private EnemyContainer _enemyContainer = new EnemyContainer();

    private void Awake()
    {
        _economy = new Economy(_tower.GUID);
        _enemyCreator = new EnemyCreator(_enemyTransformContainer);
        _tower.Init(_enemyContainer);
        _ui.Init(_economy, _tower);
        StartCoroutine(Gaming());
    }

    private void OnEnable()
    {
        _tower.Died += OnTowerDied;
        _enemyContainer.EnemyDied += OnEnemyDied;
    }

    private void OnDisable()
    {
        _tower.Died -= OnTowerDied;
        _enemyContainer.EnemyDied -= OnEnemyDied;
    }

    private void EndLevel()
    {
        StopCoroutine(Gaming());
        _enemyCreator.Stop();

        if(_tower.Health.IsDead == false)
            _ui.SetWinScreen();
    }

    private void OnTowerDied(IDamagable damagable)
    {
        damagable.Died -= OnTowerDied;
        _ui.SetGameOverScreen();
        _enemyCreator.Stop();
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _economy.AddMoney(enemy.RewardValue);
    }

    private IEnumerator Gaming()
    {
        int counter = 0;

        while (counter < _level.WaveCount)
        {
            Wave wave = _level.GetWave(counter);
            counter++;

            yield return _enemyCreator.CreatingWave(wave, _tower);
        }

        EndLevel();
    }
}
