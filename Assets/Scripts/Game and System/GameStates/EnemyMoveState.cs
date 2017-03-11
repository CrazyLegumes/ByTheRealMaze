using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : GameState {

    public override void Enter()
    {
        base.Enter();
        foreach(BaseEnemy a in gameController.enemyList)
        {
            a.Move();
        }

        StartCoroutine(init());
    }

    IEnumerator init()
    {
        yield return new WaitForSeconds(2f);
        gameController.ChangeState<WallMoveState>();
        Debug.Log(gameController.currstate);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
