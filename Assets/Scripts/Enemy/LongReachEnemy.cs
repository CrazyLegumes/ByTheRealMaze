using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongReachEnemy : BaseEnemy
{
    public override void InitStats()
    {
        stats = new StatsClass();
        stats.Strength = 3;
    }

    /*public override void ChooseAttack()
      {
           base.Act3();
           GameStateMachine.enemyCount++;
      }*/

    public override void Act1()
    {
        //2 in front
        inAttack = true;
        if (attackDirection == "up")
        {
            attackArray[0] = new Vector3(transform.position.x, 0.05f, transform.position.z + 1);
            attackArray[1] = new Vector3(transform.position.x, 0.05f, transform.position.z + 2);
        }
        else if (attackDirection == "right")
        {
            attackArray[0] = new Vector3(transform.position.x + 1, 0.05f, transform.position.z);
            attackArray[1] = new Vector3(transform.position.x + 2, 0.05f, transform.position.z);
        }
        else if (attackDirection == "down")
        {
            attackArray[0] = new Vector3(transform.position.x, 0.05f, transform.position.z - 1);
            attackArray[1] = new Vector3(transform.position.x, 0.05f, transform.position.z - 2);
        }
        else if (attackDirection == "left")
        {
            attackArray[0] = new Vector3(transform.position.x - 1, 0.05f, transform.position.z);
            attackArray[1] = new Vector3(transform.position.x - 2, 0.05f, transform.position.z);
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
                        x.GetComponent<PlayerScript>().mystats.Damage(dmg);
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
            Debug.Log("Attack 2");
            inAttack = false;
            locReached = true;
            turnsWaiting = 0;
        }
    }

    void Start ()
    {
        windup = 1;
        InitStats();
        attackSize = 2;
        attackRange = 2;
        visionRange = 4;
        base.initialize();
    }
}
