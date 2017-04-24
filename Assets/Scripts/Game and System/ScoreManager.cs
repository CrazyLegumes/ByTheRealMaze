using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static int turnsTaken;
    public static int damageTaken;
    public static int enemiesKilled;

    // Use this for initialization
    void Start () {
        turnsTaken = 0;
        damageTaken = 0;
        enemiesKilled = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
