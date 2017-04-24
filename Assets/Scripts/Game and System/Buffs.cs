using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs
{

    int turns;
    int turnspassed;
    bool activated;
    bool effectOver;
    public PlayerScript owner;



    public Buffs(int t/*turns*/  )
    {
        turns = t;
        turnspassed = 0;
        activated = false;
        effectOver = false;
    }

    public bool EffectOver
    {
        get
        {
            return effectOver;
        }

        set
        {
            effectOver = value;
        }
    }

    public virtual void Undo()
    {

    }

    public virtual void Activate()
    {
        Debug.Log("Doot Doot");
        if (!activated) {
            activated = true;
            turnspassed = 0;
            EffectOver = false;
        }
        

        if (turnspassed < turns)
        {
            turnspassed++;
            DoEffect();
            
        }

        else if( turnspassed >= turns)
        {
            EffectOver = true;
            Undo();

        }
        

    }


    protected virtual void DoEffect()
    {
        
    }

}
