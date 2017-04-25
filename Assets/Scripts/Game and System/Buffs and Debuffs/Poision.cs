using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poision : Buffs {



    public Poision(int t) : base(t)
    {
        

    }

    public override void Activate()
    {
        Debug.Log("yes?");
       
        base.Activate();

    }
    public override void Undo()
    {
        base.Undo();
    }

    void Doot()
    {
        
    }
    protected override void DoEffect()
    {
        Debug.Log("PoisonDamageBam");
        owner.mystats.Damage(1);
    }


}
