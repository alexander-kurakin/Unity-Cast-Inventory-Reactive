using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OrkConfig : EnemyConfig
{
    [field: SerializeField] public int Damage { get; private set; } = 100;
    [field: SerializeField] public int Rage { get; private set; } = 100;
}
