using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : BaseEnemy
{


    public override void playerScan()
    {
        RaycastHit playerHit;
        playerInAttackRange = false;
        seenPlayer = false;


        for (float angle = 0; angle < 360; angle += 15)
        {

            //Debug.DrawRay(transform.position, new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(angle * Mathf.Deg2Rad)) * 2f, Color.red, 5f);

            if (Physics.Raycast(transform.position, new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(angle * Mathf.Deg2Rad)), out playerHit, attackRange))
                if (playerHit.transform.gameObject.tag == "Player" /*&& angle % 90 == 0*/)
                {
                    playerLoc = playerHit.transform.position;
                    locReached = false;
                    //Debug.Log("PLAYER IN ATTACK RANGE");
                    playerInAttackRange = true;

                    seenPlayer = true;

                    break;
                }
            if (Physics.Raycast(transform.position, new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(angle * Mathf.Deg2Rad)), out playerHit, visionRange))
                if (playerHit.transform.gameObject.tag == "Player")
                {
                    playerLoc = playerHit.transform.position;
                    locReached = false;
                    chasing = true;
                    //Debug.Log("PLAYER SEEN");
                    seenPlayer = true;
                    break;
                }
        }
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

    void Start()
    {
        windup = 1;
        InitStats();
        attackSize = 1;
        attackRange = 3;
        visionRange = 6;
        base.initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
