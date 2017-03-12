using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : GameState {

    public override void Enter()
    {
        base.Enter();
        GameStateMachine.enemyCount = 0;
        foreach(BaseEnemy a in gameController.enemyList)
        {
            StartCoroutine(a.Move());
        }
         
        StartCoroutine(init());
    }

    IEnumerator init()
    {
        while (true)
        {
            yield return null;
            if (GameStateMachine.enemyCount == gameController.enemyList.Count)
            {
                yield return new WaitForSeconds(.5f);
                gameController.ChangeState<WallMoveState>();
                Debug.Log(gameController.currstate);
                yield break;
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
