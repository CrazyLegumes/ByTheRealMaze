using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemy : BaseEnemy {

    public override void ChooseAttack()
    {
        base.Act4();
        GameStateMachine.enemyCount++;
    }

    public override void InitStats()
    {
        stats = new StatsClass();
        stats.Strength = 5;
    }

    void Start () {
        windup = 1;
        InitStats();
        attackSize = 4; 
        attackRange = 4;
        visionRange = 6;
        base.initialize();
    }

	void Update () {
		
	}
}
