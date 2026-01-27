using UnityEngine;
using System.Collections;

public class Ork : Enemy
{
    private int _damage = 100;
    private int _rage = 100;

    public void Init(OrkConfig orkConfig)
    {
        _damage = orkConfig.Damage;
        _rage = orkConfig.Rage;
    }
}
