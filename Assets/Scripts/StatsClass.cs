using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatsClass {

    int strength;
    int defense;
    

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

    
}
