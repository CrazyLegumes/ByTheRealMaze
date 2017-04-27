using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEnemy : BaseEnemy
{
    public GameObject sound;



    public override void InitStats()
    {
        stats = new StatsClass();
        stats.Strength = 3;
        stats.Health = 1;
    }

    /*public override void ChooseAttack()
      {
        base.Act2();
        GameStateMachine.enemyCount++;
      }*/

    public override void Act1()
    {
        //"T" attack 1 dmg
        inAttack = true;
        if (attackDirection == "up")
        {
            attackArray[0] = new Vector3(transform.position.x, 0.05f, transform.position.z + 1);
            attackArray[1] = new Vector3(transform.position.x, 0.05f, transform.position.z + 2);
            attackArray[2] = new Vector3(transform.position.x + 1, 0.05f, transform.position.z + 2);
            attackArray[3] = new Vector3(transform.position.x - 1, 0.05f, transform.position.z + 2);
        }
        else if (attackDirection == "right")
        {
            attackArray[0] = new Vector3(transform.position.x + 1, 0.05f, transform.position.z);
            attackArray[1] = new Vector3(transform.position.x + 2, 0.05f, transform.position.z);
            attackArray[2] = new Vector3(transform.position.x + 2, 0.05f, transform.position.z + 1);
            attackArray[3] = new Vector3(transform.position.x + 2, 0.05f, transform.position.z - 1);
        }
        else if (attackDirection == "down")
        {
            attackArray[0] = new Vector3(transform.position.x, 0.05f, transform.position.z - 1);
            attackArray[1] = new Vector3(transform.position.x, 0.05f, transform.position.z - 2);
            attackArray[2] = new Vector3(transform.position.x + 1, 0.05f, transform.position.z - 2);
            attackArray[3] = new Vector3(transform.position.x - 1, 0.05f, transform.position.z - 2);
        }
        else if (attackDirection == "left")
        {
            attackArray[0] = new Vector3(transform.position.x - 1, 0.05f, transform.position.z);
            attackArray[1] = new Vector3(transform.position.x - 2, 0.05f, transform.position.z);
            attackArray[2] = new Vector3(transform.position.x - 2, 0.05f, transform.position.z + 1);
            attackArray[3] = new Vector3(transform.position.x - 2, 0.05f, transform.position.z - 1);
        }
        if (turnsWaiting == 0)
        {
            foreach (Vector3 a in attackArray)
            {
                Debug.Log("WARNING");

                if (sound != null)
                    Instantiate(sound);

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
        attackSize = 4;
        attackRange = 2;
        base.initialize();
	}
}
