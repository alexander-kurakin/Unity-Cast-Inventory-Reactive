using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ElfConfig : EnemyConfig
{
    [field: SerializeField] public int Intelligence { get; private set; } = 100;
    [field: SerializeField] public int Damage { get; private set; } = 50;
    [field: SerializeField] public int Agility { get; private set; } = 100;
}
