using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DragonConfig : EnemyConfig
{
    [field: SerializeField] public int Strength { get; private set; } = 100;
    [field: SerializeField] public int Damage { get; private set; } = 200;
    [field: SerializeField] public int FireballSize { get; private set; } = 50;
}
