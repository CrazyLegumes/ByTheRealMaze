using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int timeStep = 2; //amount of time between turns

    //State Machine
    //Player input - 2/3 sec period where player can input movement
    //Player update - Player command read and executed
    //Enemy update - Enemy AI executed
    //Map Movement - Random map movement
    //Pause - stop timescale, open pause menu
    //Game over - stop timescale, initiate post-game screen

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
