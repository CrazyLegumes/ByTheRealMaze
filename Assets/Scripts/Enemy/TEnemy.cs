using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEnemy : BaseEnemy {

    public override IEnumerator Move()
    {
        StartCoroutine(base.Move());    //if player not seen
        yield return null;
    }
    public override void ChooseAttack()
    {
        base.Act2();
        GameStateMachine.enemyCount++;
    }

    public override void InitStats()
    {
        stats = new StatsClass();
        stats.Strength = 2;
    }
    // Use this for initialization
    void Start () {
        windup = 1;
        InitStats();
        attackSize = 4; // this is 4 because its the 'T attack'
        attackRange = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
