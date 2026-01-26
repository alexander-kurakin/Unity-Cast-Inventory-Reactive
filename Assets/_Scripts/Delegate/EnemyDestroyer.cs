using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public class EnemyDestroyer
{
    private Dictionary<Enemy, List<Func<bool>>> _mainEnemyList = new();
    private List<Enemy> _keysToDelete = new();
    private List<Enemy> _copyOfMainEnemies = new();
    private float _maxEnemyLifetime;
    private int _maxEnemiesAllowed;

    public EnemyDestroyer(float maxEnemyLifetime, int maxEnemiesAllowed)
    {
        _maxEnemyLifetime = maxEnemyLifetime;
        _maxEnemiesAllowed = maxEnemiesAllowed;
    }

    public void RegisterEnemy(Enemy targetEnemy, List<Func<bool>> destroyRules)
    {
        if (_mainEnemyList.ContainsKey(targetEnemy) == false)
            _mainEnemyList.Add(targetEnemy, destroyRules);
    }

    public void KillRandomEnemy()
    {
        if (_mainEnemyList.Count == 0)
        {
            UnityEngine.Debug.LogError("Некого убивать! Сначала создайте врагов");
            return;
        }

        _copyOfMainEnemies.Clear();

        foreach (KeyValuePair<Enemy, List<Func<bool>>> kvp in _mainEnemyList)
            if (!_keysToDelete.Contains(kvp.Key))
                _copyOfMainEnemies.Add(kvp.Key);

        _copyOfMainEnemies[UnityEngine.Random.Range(0, _copyOfMainEnemies.Count)].Kill();
    }

    public void Update()
    {
        foreach (KeyValuePair<Enemy, List<Func<bool>>> kvp in _mainEnemyList)
        {
            Enemy enemy = kvp.Key;
            List<Func<bool>> _rules = kvp.Value;

            if (_keysToDelete.Contains(enemy))
                continue;

            foreach (Func<bool> delegateRule in _rules)
                if (delegateRule())
                {
                    _keysToDelete.Add(enemy);
                    break;
                }
        }

        foreach (Enemy enemy in _keysToDelete)
        {
            Object.Destroy(enemy.gameObject);
            _mainEnemyList.Remove(enemy);
        }

        _keysToDelete.Clear();
    }

    public float MaxEnemyLifetime => _maxEnemyLifetime;
    public int MaxEnemiesAllowed => _maxEnemiesAllowed;
    public int CurrentEnemiesInService => _mainEnemyList.Count;

}
