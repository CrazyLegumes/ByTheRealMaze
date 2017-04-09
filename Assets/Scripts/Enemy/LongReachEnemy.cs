using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongReachEnemy : BaseEnemy {

    public override void ChooseAttack()
    {
        base.Act3();
        GameStateMachine.enemyCount++;
    }

    public override void InitStats()
    {
        stats = new StatsClass();
        stats.Strength = 3;
    }

    void Start () {
        windup = 1;
        InitStats();
        attackSize = 2;
        attackRange = 2;
        visionRange = 4;
        base.initialize();
	}
	
	void Update () {
		
	}
}
