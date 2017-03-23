using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : BaseEnemy {


    public override IEnumerator Move()
    {
        StartCoroutine(base.Move());    //if player not seen
        yield return null;
    }

    public override void ChooseAttack()
    {
        base.Act5();
        GameStateMachine.enemyCount++;
    }
    public override void InitStats()
    {
        stats = new StatsClass();
        stats.Strength = 2;
    }


    void Start () {
        windup = 1;
        InitStats();
        attackSize = 1;
        attackRange = 3;
        visionRange = 6;
        base.initialize();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
