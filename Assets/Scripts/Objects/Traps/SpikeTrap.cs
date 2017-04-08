using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap :Traps {



    void Awake()
    {
        MyEffect = effect.instant;
        Activated = false;
        Activator = null; 
        
        
    }


    
    


    public override void InstantActivation()
    {
        if(Activator != null)
        {
            Activator.mystats.Damage(1);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
