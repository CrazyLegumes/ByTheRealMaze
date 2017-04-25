using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : GameState {
    

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(MoveUs());
        
    }

    IEnumerator MoveUs()
    {

        while(gameController.spellCount > 0)
        {
            yield return null;
        }
        GameStateMachine.enemyCount = 0;
        foreach (BaseEnemy a in gameController.enemyList.ToArray())
        {

            if (a.Stats.Dead)
            {
                ParticleSystem blood = gameController.player1.GetComponent<PlayerScript>().enemyKill;
                ParticleSystem temp = Instantiate(blood, a.transform.position, Quaternion.identity);
                Destroy(temp, temp.duration);
                ScoreManager.enemiesKilled++;
                gameController.enemyList.Remove(a);
                GameObject.Destroy(a.gameObject);
                continue;
            }


            if (a.inAttack)
            {
                a.Act1();
                GameStateMachine.enemyCount++;
                continue;
            }

            a.playerScan();

            if (a.playerInAttackRange) //or winding up
            {
                a.Act1();
                GameStateMachine.enemyCount++;
            }
            else if (a.seenPlayer || (a.chasing && !a.locReached))
            {
                StartCoroutine(a.Chase());
            }
            else
            {
                StartCoroutine(a.Move());
            }

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

                //yield return new WaitForSeconds(.5f);

                if (GameStateMachine.over == true)      //GAME OVER
                {
                    Time.timeScale = 0;
                }

           
                //yield return new WaitForSeconds(.001f);
                gameController.ChangeState<WallMoveState>();
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
