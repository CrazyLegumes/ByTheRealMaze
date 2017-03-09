using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State {
    

    protected GameStateMachine gameController;

    protected PlayerScript P1; 
    


    protected virtual void Awake()
    {
        gameController = GameStateMachine.instance;
        P1 = gameController.player1.GetComponent<PlayerScript>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
