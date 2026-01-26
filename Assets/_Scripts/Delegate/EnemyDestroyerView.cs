using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDestroyerView : MonoBehaviour
{
    [SerializeField] private Toggle _registerIsDeadEnemy;
    [SerializeField] private Toggle _registerTimeoutEnemy;
    [SerializeField] private Toggle _registerTooMuchEnemies;
    [SerializeField] private Button _registerEnemyButton;
    [SerializeField] private Button _killRandomEnemyButton;
    [SerializeField] private TMP_Text _infoText;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;

    private EnemyDestroyer _enemyDestroyer;
    private List<Func<bool>> _rulesList;

    public void Init(EnemyDestroyer enemyDestroyer)
    {
        _enemyDestroyer = enemyDestroyer;
    }

    private void Awake()
    {
        _registerEnemyButton.onClick.AddListener(OnRegisterEnemyClick);
        _killRandomEnemyButton.onClick.AddListener(OnKillRandomEnemyClick);
    }

    private void Update()
    {
        if (_enemyDestroyer != null)
            _infoText.text = "Врагов в сервисе: " + _enemyDestroyer.CurrentEnemiesInService;
    }

    private void OnDestroy()
    {
        _registerEnemyButton.onClick.RemoveListener(OnRegisterEnemyClick);
        _killRandomEnemyButton.onClick.RemoveListener(OnKillRandomEnemyClick);
    }

    private void OnRegisterEnemyClick()
    {
        if (!_registerIsDeadEnemy.isOn && !_registerTimeoutEnemy.isOn && !_registerTooMuchEnemies.isOn)
        {
            Debug.LogError("Не задано ни одно условие! Выберите хотя бы одно!");
            return;
        }

        Enemy enemyToSpawn = Instantiate(_enemyPrefab, new Vector3(_spawnPoint.position.x + UnityEngine.Random.Range(-2f, 2f), _spawnPoint.position.y, _spawnPoint.position.z), Quaternion.identity, null); ;
        _rulesList = new List<Func<bool>>();

        if (_registerIsDeadEnemy.isOn)
            _rulesList.Add(() => enemyToSpawn.IsDead == true);

        if (_registerTimeoutEnemy.isOn)
            _rulesList.Add(() => enemyToSpawn.Lifetime > _enemyDestroyer.MaxEnemyLifetime);

        if (_registerTooMuchEnemies.isOn)
            _rulesList.Add(() => _enemyDestroyer.CurrentEnemiesInService > _enemyDestroyer.MaxEnemiesAllowed);

        _enemyDestroyer.RegisterEnemy(enemyToSpawn, _rulesList);
    }

    private void OnKillRandomEnemyClick()
    {
        _enemyDestroyer.KillRandomEnemy();
    }
}
