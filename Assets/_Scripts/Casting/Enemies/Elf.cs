using UnityEngine;
using System.Collections;

public class Elf : Enemy
{
    private int _intelligence = 100;
    private int _damage = 100;
    private int _agility = 100;

    public void Init(ElfConfig elfConfig)
    {
        _damage = elfConfig.Damage;
        _intelligence = elfConfig.Intelligence;
        _agility = elfConfig.Agility;
    }
}
