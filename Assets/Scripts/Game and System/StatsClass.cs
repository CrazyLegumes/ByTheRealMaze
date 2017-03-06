using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatsClass {

    int strength;
    int defense;
    int movespeed;
    int health;
    int maxhealth;
    int sightRange;
    bool dead;

    public int Strength
    {
        get
        {
            return strength;
        }

        set
        {
            strength = value;
        }
    }

    public int Defense
    {
        get
        {
            return defense;
        }

        set
        {
            defense = value;
        }
    }

    public int Movespeed
    {
        get
        {
            return movespeed;
        }

        set
        {
            movespeed = value;
        }
    }

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public int Maxhealth
    {
        get
        {
            return maxhealth;
        }

        set
        {
            maxhealth = value;
        }
    }

    public bool Dead
    {
        get
        {
            return dead;
        }

        set
        {
            dead = value;
        }
    }

    public int SightRange
    {
        get
        {
            return sightRange;
        }

        set
        {
            sightRange = value;
        }
    }

    public virtual void Heal(int hp) { }
    public virtual void Damage(int dmg) { }


}
