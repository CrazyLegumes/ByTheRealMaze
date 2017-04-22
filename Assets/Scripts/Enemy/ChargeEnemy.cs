﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemy : BaseEnemy
{
    public override void InitStats()
    {
        stats = new StatsClass();
        stats.Strength = 5;
    }

    /*public override void ChooseAttack()
    {
        base.Act4();
        GameStateMachine.enemyCount++;
    }*/

    public override void Act1()
    {
        //charge attack, 4 tiles in front, 4 dmg
        inAttack = true;
        if (attackDirection == "up")
        {
            attackArray[0] = new Vector3(transform.position.x, 0.05f, transform.position.z + 1);
            attackArray[1] = new Vector3(transform.position.x, 0.05f, transform.position.z + 2);
            attackArray[2] = new Vector3(transform.position.x, 0.05f, transform.position.z + 3);
            attackArray[3] = new Vector3(transform.position.x, 0.05f, transform.position.z + 4);
            chargeDirection = new Vector3(0, 0, 1);
        }
        else if (attackDirection == "right")
        {
            attackArray[0] = new Vector3(transform.position.x + 1, 0.05f, transform.position.z);
            attackArray[1] = new Vector3(transform.position.x + 2, 0.05f, transform.position.z);
            attackArray[2] = new Vector3(transform.position.x + 3, 0.05f, transform.position.z);
            attackArray[3] = new Vector3(transform.position.x + 4, 0.05f, transform.position.z);
            chargeDirection = new Vector3(1, 0, 0);
        }
        else if (attackDirection == "down")
        {
            attackArray[0] = new Vector3(transform.position.x, 0.05f, transform.position.z - 1);
            attackArray[1] = new Vector3(transform.position.x, 0.05f, transform.position.z - 2);
            attackArray[2] = new Vector3(transform.position.x, 0.05f, transform.position.z - 3);
            attackArray[3] = new Vector3(transform.position.x, 0.05f, transform.position.z - 4);
            chargeDirection = new Vector3(0, 0, -1);
        }
        else if (attackDirection == "left")
        {
            attackArray[0] = new Vector3(transform.position.x - 1, 0.05f, transform.position.z);
            attackArray[1] = new Vector3(transform.position.x - 2, 0.05f, transform.position.z);
            attackArray[2] = new Vector3(transform.position.x - 3, 0.05f, transform.position.z);
            attackArray[3] = new Vector3(transform.position.x - 4, 0.05f, transform.position.z);
            chargeDirection = new Vector3(-1, 0, 0);
        }
        if (turnsWaiting == 0)
        {
            foreach (Vector3 a in attackArray)
            {
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
            RaycastHit hit;
            if (Physics.Raycast(transform.position, chargeDirection, out hit, 4.0f))
            {
                Debug.DrawLine(transform.position, transform.position + chargeDirection, Color.red, 4.0f);
                if (hit.transform.gameObject.tag == "Wall")
                {
                    int newDes = (int)Mathf.Floor(hit.distance);

                    StartCoroutine(chargeMove(newDes));
                    goingToGetHit = false;
                }
                else if (hit.transform.gameObject.tag == "Player")
                {
                    int newDes = (int)Mathf.Floor(hit.distance);
                    goingToGetHit = true;
                    StartCoroutine(chargeMove(newDes));
                }
            }
            else
            {
                int newDes = 4;
                StartCoroutine(chargeMove(newDes));
            }
            foreach (Transform child in transform)
            {
                if (child.gameObject.tag == "Warning")
                {
                    Destroy(child.gameObject);
                }
            }
            turnsWaiting = 0;
            inAttack = false;
            locReached = true;
        }
    }

    public virtual IEnumerator chargeMove(int newDes)
    {
        Vector3 destination = transform.position + (chargeDirection * newDes);

        while (transform.position != destination)
        {
            transform.position = Vector3.Lerp(transform.position, destination, 10 * Time.deltaTime);

            yield return null;
        }
        if (goingToGetHit)
        {
            int dmg = stats.Strength - FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().mystats.Defense;
            if (dmg <= 0)
                dmg = 1;
            FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().mystats.Damage(dmg);
            FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().myUi.UpdateCurrentHealth();
        }
        yield return null;
    }

    void Start () {
        windup = 1;
        InitStats();
        attackSize = 4; 
        attackRange = 4;
        visionRange = 6;
        base.initialize();
    }
}
