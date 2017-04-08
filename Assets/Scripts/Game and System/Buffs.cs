using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{

    int turns;
    int turnspassed;
    bool activated;
    bool effectOver;
    

    public virtual void Activate(PlayerScript owner)
    {
        if (!activated) {
            activated = true;
            turnspassed = 0;
            effectOver = false;
        }
        

        if (turnspassed < turns)
        {
            turnspassed++;
        }

        else if( turnspassed >= turns)
        {
            effectOver = true;

        }

    }

}
