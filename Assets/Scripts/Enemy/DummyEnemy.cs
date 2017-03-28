using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : BaseEnemy {

    public override IEnumerator Move()
    {
        StartCoroutine(base.Move());    //if player not seen
        yield return null;
    }
    // Use this for initialization
    void Start () {
        windup = 1;
        base.InitStats();
        //Stats.Health = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
