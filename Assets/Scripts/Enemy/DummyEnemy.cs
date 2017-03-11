using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : BaseEnemy {

    public override void Move()
    {
        base.Move();
    }
    // Use this for initialization
    void Start () {
        Stats.Health = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
