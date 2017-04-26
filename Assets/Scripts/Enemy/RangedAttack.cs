using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : BaseEnemy
{

    public GameObject AttackSound;

    public override void InitStats()
    {
        stats = new StatsClass();
        stats.Strength = 2;
    }
    
    /*public override void ChooseAttack()
    {
        base.Act5();
        GameStateMachine.enemyCount++;
    }*/

    public override void Act1()
    {
        //ranged attack
        inAttack = true;
        attackArray[0] = new Vector3(playerLoc.x, .05f, playerLoc.z);
        if (turnsWaiting == 0)
        {
            if (AttackSound != null)
                GameObject.Instantiate(AttackSound);

            foreach (Vector3 a in attackArray)
            {
                Debug.Log("WARNING");
                GameObject b = Instantiate(attackWarning, a, Quaternion.identity, transform);
                b.transform.localScale = new Vector3(b.transform.localScale.x / transform.localScale.x,
                    b.transform.localScale.y / transform.localScale.y,
                    b.transform.localScale.z / transform.localScale.z);
                b.transform.position = new Vector3(b.transform.position.x, 0.05f, b.transform.position.z);
            }
            turnsWaiting++;
        }
        else if (turnsWaiting == windup)
        {
            foreach (Vector3 a in attackArray)
            {
                Collider[] hitobjects = Physics.OverlapBox(a, new Vector3(0.5f, .5f, .5f), Quaternion.identity, HitMask);
                foreach (Collider x in hitobjects)
                {
                    if (x.transform.name == "Player")
                    {
                        int dmg = stats.Strength - x.GetComponent<PlayerScript>().mystats.Defense;
                        if (dmg <= 0)
                            dmg = 1;
                        ScoreManager.damageTaken += dmg;

                        GameObject damageSound = x.GetComponent<PlayerScript>().DamagedSound;
                        if (damageSound != null)
                            GameObject.Instantiate(damageSound);

                        x.GetComponent<PlayerScript>().mystats.Damage(dmg);
                        if (x.GetComponent<PlayerScript>().mystats.Health == 0)
                        {
                            ParticleSystem temp = Instantiate(x.GetComponent<PlayerScript>().playerKill, x.transform.position, Quaternion.Euler(90, 0, 0), x.gameObject.transform);
                            Destroy(temp, temp.duration);
                        }
                        else
                        {
                            ParticleSystem temp = Instantiate(x.GetComponent<PlayerScript>().blood, x.transform.position, attackAngle, x.gameObject.transform);
                            Destroy(temp, temp.duration);
                        }
                        x.GetComponent<PlayerScript>().mystats.Damaged = true;
                        x.GetComponent<PlayerScript>().myUi.UpdateCurrentHealth();
                    }
                }
            }
            foreach (Transform child in transform)
            {
                if (child.gameObject.tag == "Warning")
                {
                    Destroy(child.gameObject);
                }
            }
            Debug.Log("Attack 5");
            inAttack = false;
            locReached = true;
            turnsWaiting = 0;
        }
    }

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

    void Start()
    {
        windup = 1;
        InitStats();
        attackSize = 1;
        attackRange = 3;
        visionRange = 6;
        base.initialize();
    }
}
