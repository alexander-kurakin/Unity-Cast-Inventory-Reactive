using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class EnemySpawner
{
    private Ork _orkPrefab;
    private Elf _elfPrefab;
    private Dragon _dragonPrefab;

    public EnemySpawner(Ork orkPrefab, Elf elfPrefab, Dragon dragonPrefab)
    {
        _orkPrefab = orkPrefab;
        _elfPrefab = elfPrefab;
        _dragonPrefab = dragonPrefab;
    }

    public Enemy SpawnEnemy(EnemyConfig enemyConfig, Vector3 position)
    {
        switch (enemyConfig)
        {
            case OrkConfig orkConfig:
                Ork ork = Object.Instantiate(_orkPrefab, position, Quaternion.identity);
                ork.Init(orkConfig);
                return ork;

            case ElfConfig elfConfig:
                Elf elf = Object.Instantiate(_elfPrefab, position, Quaternion.identity);
                elf.Init(elfConfig);
                return elf;

            case DragonConfig dragonConfig:
                Dragon dragon = Object.Instantiate(_dragonPrefab, position, Quaternion.identity);
                return dragon;

            default:
                throw new ArgumentOutOfRangeException(nameof(enemyConfig), enemyConfig, "Конфиг не найден!");
        }

    }
}
