using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap :Traps {

    [SerializeField]
    Animator[] Spikes;
    

    void Awake()
    {
        MyEffect = effect.instant;
        Activated = false;
        Activator = null;
        function = InstantActivation; 
        
        
    }


    
    


    public override void InstantActivation()
    {
        if(Activator != null)
        {
            
            Activator.mystats.Damage(1);
            ScoreManager.damageTaken++;
            Activator.myUi.UpdateCurrentHealth();
            foreach (Animator e in Spikes)
            {
                e.SetBool("Hit Spike", true);
                
            }

            
        }

       
       
    }


    public void Reset()
    {
        foreach (Animator e in Spikes)
        {
            e.SetBool("Hit Spike", false);

        }
        Activated = false;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
