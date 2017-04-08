using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour {
    public enum effect
    {
        instant,
        debuff,

    }

    effect myEffect;
    bool activated;
    Buffs debuff;
    PlayerScript activator;

    public virtual void InstantActivation() { }

    public virtual void DebuffActivation() { }

    public effect MyEffect
    {
        get
        {
            return myEffect;
        }

        set
        {
            myEffect = value;
        }
    }

    public bool Activated
    {
        get
        {
            return activated;
        }

        set
        {
            activated = value;
        }
    }

    public Buffs Debuff
    {
        get
        {
            return debuff;
        }

        set
        {
            debuff = value;
        }
    }

    public PlayerScript Activator
    {
        get
        {
            return activator;
        }

        set
        {
            activator = value;
        }
    }
}
