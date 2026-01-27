using UnityEngine;
using System.Collections;

public class Dragon : Enemy
{
    private int _strength = 100;
    private int _damage = 200;
    private int _fireballSize = 50;

    public void Init(DragonConfig dragonConfig)
    {
        _damage = dragonConfig.Damage;
        _strength = dragonConfig.Strength;
        _fireballSize = dragonConfig.FireballSize;
    }
}
