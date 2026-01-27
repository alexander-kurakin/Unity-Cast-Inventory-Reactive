using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingExample : MonoBehaviour
{
    [Header("Config arrays")]
    [SerializeField] private OrkConfig[] _orkConfigs;
    [SerializeField] private ElfConfig[] _elfConfigs;
    [SerializeField] private DragonConfig[] _dragonConfigs;
    [Header("Spawn settings")]
    [SerializeField] private float _minSpawnRadius = 5f;
    [SerializeField] private float _maxSpawnRadius = 25f;
    [Header("Prefabs")]
    [SerializeField] private Ork _orkPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private Dragon _dragonPrefab;

    private EnemySpawner _enemySpawner;
    

    private void Awake()
    {
        _enemySpawner = new EnemySpawner(_orkPrefab, _elfPrefab, _dragonPrefab);
    }

    private void Start()
    {
        ConfiguredSpawn();
    }

    private void ConfiguredSpawn()
    {
        for (int i = 0; i < 3; i++)
        {
            _enemySpawner.SpawnEnemy(_orkConfigs[Random.Range(0, _orkConfigs.Length)], GetRandomPoint());
            _enemySpawner.SpawnEnemy(_elfConfigs[Random.Range(0, _elfConfigs.Length)], GetRandomPoint());
            _enemySpawner.SpawnEnemy(_dragonConfigs[Random.Range(0, _dragonConfigs.Length)], GetRandomPoint());
        }
    }

    private Vector3 GetRandomPoint()
    {
        Vector3 randomPoint = Random.insideUnitSphere;
        randomPoint.y = 0;
        Vector3 spawnOffset = randomPoint.normalized * Random.Range(_minSpawnRadius, _maxSpawnRadius);
        Vector3 resultPosition = transform.position + spawnOffset;

        return resultPosition;
    }
}
