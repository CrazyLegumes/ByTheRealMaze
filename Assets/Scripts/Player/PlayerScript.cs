using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ExecuteInEditMode]
public class PlayerScript : MonoBehaviour {
    [SerializeField]
    public StatsClass mystats;

    Input myinput;

	// Use this for initialization
	void Start () {
        mystats = new StatsClass();
        InitBaseStats();

    }

    void InitBaseStats()
    {
        mystats.Strength = 1;
        mystats.Defense = 1;
        mystats.Movespeed = 1;
        mystats.Health = mystats.Maxhealth = 5;
        mystats.SightRange = 10;
        mystats.Dead = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
