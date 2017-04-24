using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StatsClass
{
    public ParticleSystem blood;

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

    [SerializeField]
    bool damaged;




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

    public bool Damaged
    {
        get
        {
            return damaged;
        }

        set
        {
            damaged = value;
        }
    }

  

    public virtual void Heal(int hp)
    {
        health += hp;
        if (health > maxhealth)
            health = maxhealth;
    }
    public virtual void Damage(int dmg)
    { 
        Damaged = true;
        health -= dmg;
        if (health <= 0)
        {
            health = 0;
            dead = true;
        }
        damaged = true;
    }







    public static StatsClass operator +(StatsClass a, StatsClass b)
    {
        a.strength += b.strength;
        a.defense += b.defense;
        a.maxhealth += b.maxhealth;
        return a;

    }
    public static StatsClass operator -(StatsClass a, StatsClass b)
    {
        StatsClass x = new StatsClass();
        x.strength = a.strength - b.strength;
        x.defense = a.defense - b.defense;
        x.maxhealth = a.maxhealth - b.maxhealth;
        return x;
    }


    public override string ToString()
    {
        return string.Format("Strenghth: {0}\n Defense: {1}\n Health: {2} / {3}", strength, defense, health, maxhealth);
    }


    public StatsClass()
    {
        strength = 0;
        defense = 0;
        movespeed = 0;
        health = maxhealth = 0;
        sightRange = 0;
        dead = false;
        string path = "BloodParticles";
        blood = Resources.Load<ParticleSystem>(path);
    }





}
