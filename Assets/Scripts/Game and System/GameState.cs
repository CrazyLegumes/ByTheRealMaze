using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State {


    protected GameStateMachine gameController;
    PlayerScript player1;


    protected virtual void Awake()
    {
        gameController = GameStateMachine.instance;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
