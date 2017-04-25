using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTrap : Traps {


    void Awake()
    {
        MyEffect = effect.debuff;

        Activated = false;
        Debuff = new Poision(2);

    }

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
