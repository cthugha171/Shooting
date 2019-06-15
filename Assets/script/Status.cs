using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Status
{
    public string name;
    [SerializeField] int hp;
    [SerializeField] int atk;
    [SerializeField] int def;
    [SerializeField] bool isDead;

    public Status(string _name, int _hp, int _atk, int _def)
    {
        name = _name;
        hp = _hp;
        atk = _atk;
        def = _def;
        isDead = false;
    }

    public void Damage(int otherAtk)
    {
        int damage = otherAtk - def;

        hp -= damage;

        if (hp <= 0) isDead = true;
    }
}
