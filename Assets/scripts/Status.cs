using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Status
{
    public string name;
    public int atk;
    public int Tatk;
    public int hp;
    public int def;
    public bool isDead;

    public Status(string _name, int _hp, int _atk,int _Tatk, int _def)
    {
        name = _name;
        hp = _hp;
        atk = _atk;
        Tatk = _Tatk;
        def = _def;
        isDead = false;
    }

    public Status Damage(int otherAtk)
    {
        int damage = otherAtk - def;

        hp -= damage;

        if (hp <= 0) isDead = true;

        return this;
    }
}
