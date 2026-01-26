using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegateExample : MonoBehaviour
{
    [SerializeField] EnemyDestroyerView _enemyDestroyerView;
    [SerializeField] private float _maxEnemyLifetime = 10f;
    [SerializeField] private int _maxEnemiesAllowed = 10;

    private EnemyDestroyer _enemyDestroyer;

    private void Awake()
    {
        _enemyDestroyer = new EnemyDestroyer(_maxEnemyLifetime, _maxEnemiesAllowed);
        _enemyDestroyerView.Init(_enemyDestroyer);
    }

    private void Update()
    {
        _enemyDestroyer.Update();
    }
}
