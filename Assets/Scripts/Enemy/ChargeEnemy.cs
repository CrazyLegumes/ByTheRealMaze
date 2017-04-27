using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemy : BaseEnemy
{

    public GameObject WarningSound;
    public GameObject DeathSound;

    public override void InitStats()
    {
        stats = new StatsClass();
        stats.Strength = 4;
        stats.Health = 3;
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
            if (WarningSound != null)
                GameObject.Instantiate(WarningSound);

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
        Vector3 desire = Vector3.Normalize(destination - transform.position) * 15 * Time.deltaTime;
        Vector3 total = Vector3.zero;

        while (Vector3.Distance(destination, transform.position) > .2f)
        {
            transform.position += desire;
            total += desire;
            if (Mathf.Abs(total.x) > newDes || Mathf.Abs(total.z) > newDes)
                break;

            yield return null;
        }
        transform.position = destination;
        if (goingToGetHit)
        {
                int dmg = stats.Strength - FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().mystats.Defense;
                if (dmg <= 0)
                    dmg = 1;
                ScoreManager.damageTaken += dmg;
                FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().mystats.Damage(dmg);

            GameObject damageSound = FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().DamagedSound;
            if (damageSound != null)
                GameObject.Instantiate(damageSound);

            if (FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().mystats.Health == 0)
                {
                    ParticleSystem temp = Instantiate(FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().playerKill, FindObjectOfType<PlayerScript>().transform.position, Quaternion.Euler(90, 0, 0), FindObjectOfType<PlayerScript>().gameObject.transform);
                    Destroy(temp, temp.duration);
                }
                else
                {
                    ParticleSystem temp = Instantiate(FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().blood, FindObjectOfType<PlayerScript>().transform.position, attackAngle, FindObjectOfType<PlayerScript>().gameObject.transform);
                    Destroy(temp, temp.duration);
                }

            FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().mystats.Damage(dmg);
            FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().myUi.UpdateCurrentHealth();
        }
        chasing = false;
        seenPlayer = false;
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

    private void OnDestroy()
    {
        if (DeathSound != null)
            GameObject.Instantiate(DeathSound);
    }


}
