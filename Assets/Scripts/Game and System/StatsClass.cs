using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatsClass {
    [SerializeField]
    int strength;

    [SerializeField]
    int defense;

    [SerializeField]
    int movespeed;

    [SerializeField]
    int health;

    [SerializeField]
    int maxhealth;

    [SerializeField]
    int sightRange;

    [SerializeField]
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



    public StatsClass()
    {
        strength = 0;
        defense = 0;
        movespeed = 0;
        health = maxhealth = 0;
        sightRange = 0;
        dead = false;
    }


    


}
