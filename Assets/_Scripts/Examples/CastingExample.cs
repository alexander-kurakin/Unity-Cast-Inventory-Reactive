using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingExample : MonoBehaviour
{
    [SerializeField] private OrkConfig[] _orkConfigs;
    [SerializeField] private ElfConfig[] _elfConfigs;
    [SerializeField] private DragonConfig[] _dragonConfigs;

    [SerializeField] private Ork _orkPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private Dragon _dragonPrefab;

    private EnemySpawner _enemySpawner;
    private float _spawnRadius = 5f;

    private void Awake()
    {
        _enemySpawner = new EnemySpawner(_orkPrefab, _elfPrefab, _dragonPrefab);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _enemySpawner.SpawnEnemy(_orkConfigs[Random.Range(0, _orkConfigs.Length)], GetRandomPoint());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _enemySpawner.SpawnEnemy(_elfConfigs[Random.Range(0, _elfConfigs.Length)], GetRandomPoint());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _enemySpawner.SpawnEnemy(_dragonConfigs[Random.Range(0, _dragonConfigs.Length)], GetRandomPoint());
        }

    }

    private Vector3 GetRandomPoint()
    {
        Vector3 randomPoint = Random.insideUnitSphere;
        randomPoint.y = 0;
        Vector3 spawnOffset = randomPoint.normalized * Random.Range(0, _spawnRadius);
        Vector3 resultPosition = transform.position + spawnOffset;

        return resultPosition;
    }
}
