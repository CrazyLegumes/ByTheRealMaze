using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : BaseEnemy
{
    public override void InitStats()
    {
        stats = new StatsClass();
        stats.Strength = 4;
    }



    public override void Act1()
    {
        GameObject player = FindObjectOfType<PlayerScript>().gameObject;
        int attackType = 0;
        if (Vector3.Distance(player.transform.position, transform.position) > 3)
        {
            attackType = 1; // do the close range attack
        }
        else
        {
            attackType = 0; // do the far away attack
        }

        if (attackType == 1)
        {
            inAttack = true;
            if (attackDirection == "up")
            {
                attackArray[0] = new Vector3(transform.position.x, 0.05f, transform.position.z + 1);
                attackArray[1] = new Vector3(transform.position.x, 0.05f, transform.position.z + 2);
                attackArray[2] = new Vector3(transform.position.x, 0.05f, transform.position.z + 3);
                attackArray[3] = new Vector3(transform.position.x - 1, 0.05f, transform.position.z + 2);
                attackArray[4] = new Vector3(transform.position.x + 1, 0.05f, transform.position.z + 2);
                attackArray[5] = new Vector3(transform.position.x - 1, 0.05f, transform.position.z + 3);
                attackArray[6] = new Vector3(transform.position.x + 1, 0.05f, transform.position.z + 3);


            }
            else if (attackDirection == "right")
            {
                attackArray[0] = new Vector3(transform.position.x + 1, 0.05f, transform.position.z);
                attackArray[1] = new Vector3(transform.position.x + 2, 0.05f, transform.position.z);
                attackArray[2] = new Vector3(transform.position.x + 3, 0.05f, transform.position.z);
                attackArray[3] = new Vector3(transform.position.x + 2, 0.05f, transform.position.z + 1);
                attackArray[4] = new Vector3(transform.position.x + 2, 0.05f, transform.position.z - 1);
                attackArray[5] = new Vector3(transform.position.x + 3, 0.05f, transform.position.z + 1);
                attackArray[6] = new Vector3(transform.position.x + 3, 0.05f, transform.position.z - 1);
            }
            else if (attackDirection == "down")
            {
                attackArray[0] = new Vector3(transform.position.x, 0.05f, transform.position.z - 1);
                attackArray[1] = new Vector3(transform.position.x, 0.05f, transform.position.z - 2);
                attackArray[2] = new Vector3(transform.position.x, 0.05f, transform.position.z - 3);
                attackArray[3] = new Vector3(transform.position.x - 1, 0.05f, transform.position.z - 2);
                attackArray[4] = new Vector3(transform.position.x + 1, 0.05f, transform.position.z - 2);
                attackArray[5] = new Vector3(transform.position.x - 1, 0.05f, transform.position.z - 3);
                attackArray[6] = new Vector3(transform.position.x + 1, 0.05f, transform.position.z - 3);
            }
            else if (attackDirection == "left")
            {
                attackArray[0] = new Vector3(transform.position.x - 1, 0.05f, transform.position.z);
                attackArray[1] = new Vector3(transform.position.x - 2, 0.05f, transform.position.z);
                attackArray[2] = new Vector3(transform.position.x - 3, 0.05f, transform.position.z);
                attackArray[3] = new Vector3(transform.position.x - 2, 0.05f, transform.position.z + 1);
                attackArray[4] = new Vector3(transform.position.x - 2, 0.05f, transform.position.z - 1);
                attackArray[5] = new Vector3(transform.position.x - 3, 0.05f, transform.position.z + 1);
                attackArray[6] = new Vector3(transform.position.x - 3, 0.05f, transform.position.z - 1);
            }
        }
        else if (attackType == 1)
        {
            if (attackDirection == "up")
            {
                attackArray[0] = new Vector3(transform.position.x, 0.05f, transform.position.z + 1);
                attackArray[1] = new Vector3(transform.position.x, 0.05f, transform.position.z + 2);
                attackArray[2] = new Vector3(transform.position.x, 0.05f, transform.position.z + 3);
                attackArray[3] = new Vector3(transform.position.x, 0.05f, transform.position.z + 4);


            }
            else if (attackDirection == "right")
            {
                attackArray[0] = new Vector3(transform.position.x + 1, 0.05f, transform.position.z);
                attackArray[1] = new Vector3(transform.position.x + 2, 0.05f, transform.position.z);
                attackArray[2] = new Vector3(transform.position.x + 3, 0.05f, transform.position.z);
                attackArray[3] = new Vector3(transform.position.x + 4, 0.05f, transform.position.z);
            }
            else if (attackDirection == "down")
            {
                attackArray[0] = new Vector3(transform.position.x, 0.05f, transform.position.z - 1);
                attackArray[1] = new Vector3(transform.position.x, 0.05f, transform.position.z - 2);
                attackArray[2] = new Vector3(transform.position.x, 0.05f, transform.position.z - 3);
                attackArray[3] = new Vector3(transform.position.x, 0.05f, transform.position.z - 4);
            }
            else if (attackDirection == "left")
            {
                attackArray[0] = new Vector3(transform.position.x - 1, 0.05f, transform.position.z);
                attackArray[1] = new Vector3(transform.position.x - 2, 0.05f, transform.position.z);
                attackArray[2] = new Vector3(transform.position.x - 3, 0.05f, transform.position.z);
                attackArray[3] = new Vector3(transform.position.x - 4, 0.05f, transform.position.z);
            }
        }
        if (turnsWaiting == 0)
        {
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
                        if (attackType == 0)
                        {
                            if (attackDirection == "up")
                            {
                                if (player.transform.position.z - transform.position.z == 3)
                                {
                                    dmg = dmg * 2;
                                }
                            }
                            if(attackDirection == "right")
                            {
                                if(player.transform.position.x - transform.position.x == 3)
                                {
                                    dmg = dmg * 2;
                                }
                            }
                            if (attackDirection == "down")
                            {
                                if (player.transform.position.z - transform.position.z == -3)
                                {
                                    dmg = dmg * 2;
                                }
                            }
                            if (attackDirection == "left")
                            {
                                if (player.transform.position.x - transform.position.x == -3)
                                {
                                    dmg = dmg * 2;
                                }
                            }
                        }
                        ScoreManager.damageTaken += dmg;
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

            Debug.Log("Boss attack");
            inAttack = false;
            locReached = true;
            turnsWaiting = 0;
        }
    }



    void Start()
    {
        windup = 1;
        InitStats();
        attackSize = 7;
        attackRange = 4;
        visionRange = 5;
        base.initialize();
    }
}
