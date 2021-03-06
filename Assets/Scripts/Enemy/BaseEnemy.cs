﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseEnemy : MonoBehaviour
{
    protected StatsClass stats;
    protected string enemyName;
    protected GameObject attackWarning;
    protected int windup = 1;
    public int attackSize = 1;
    public float visionRange = 3;
    public float attackRange = 1;
    public Vector3[] attackArray;
    public bool seenPlayer;
    public bool locReached;
    public bool chasing;
    public bool inAttack;
    public bool playerInAttackRange;
    public Vector3 playerLoc;
    public LayerMask HitMask;
    public string attackDirection = null;
    protected Quaternion attackAngle;
    protected int turnsWaiting = 0;
    protected Vector3 chargeDirection;
    protected bool goingToGetHit = false;
    protected Animator anim;

    public virtual void initialize()
    {
        attackArray = new Vector3[attackSize];
        attackWarning = (GameObject)Resources.Load("Prefabs/AttackWarning", typeof(GameObject));
        chasing = false;
        anim = GetComponentInChildren<Animator>();
    }

    public StatsClass Stats
    {
        get
        {
            return stats;
        }

        set
        {
            stats = value;
        }
    }

    public string EnemyName
    {
        get
        {
            return enemyName;
        }

        set
        {
            enemyName = value;
        }
    }

    public virtual void InitStats()
    {
        stats = new StatsClass();
        stats.Strength = 1;
    }

    // Possible Max of 6 actions and move. 
    //Or can be set for each enemy instead of defining them here 
    public virtual IEnumerator Move()
    {

        bool up = true;
        bool down = true;
        bool right = true;
        bool left = true;
        RaycastHit RC;
        if (Physics.Linecast(transform.position, transform.position + Vector3.forward, out RC))
            if (RC.transform.gameObject.tag == "Wall")
            {
                //Debug.Log("wall above");
                up = false;
            }
        if (Physics.Linecast(transform.position, transform.position + Vector3.back, out RC))
            if (RC.transform.gameObject.tag == "Wall")
            {
                //Debug.Log("wall below");
                down = false;
            }
        if (Physics.Linecast(transform.position, transform.position + Vector3.right, out RC))
            if (RC.transform.gameObject.tag == "Wall")
            {
                //Debug.Log("wall right");
                right = false;
            }
        if (Physics.Linecast(transform.position, transform.position + Vector3.left, out RC))
            if (RC.transform.gameObject.tag == "Wall")
            {
                //Debug.Log("wall left");
                left = false;
            }

        int randMove = 0;
        while (true)
        {
            yield return null;
            randMove = Random.Range(1, 5);
            //Debug.Log(randMove + " is the direction");
           if (!left && !right && !down && !up)
            {
                randMove = 0;
                break;
            }
            else if (up == false && randMove == 1)
            {
                continue;
            }
            else if (down == false && randMove == 2)
            {
                continue;
            }
            else if (right == false && randMove == 3)
            {
                continue;
            }
            else if (left == false && randMove == 4)
            {
                continue;
            }
            
            break;
        }
        //Debug.Log(randMove + " is the FINAL direction");
        Vector3 destination = Vector3.zero;

        switch (randMove)
        {
            case 1:
                destination = transform.position + Vector3.forward;
                break;

            case 2:
                destination = transform.position + Vector3.back;
                break;

            case 3:
                destination = transform.position + Vector3.right;
                break;

            case 4:
                destination = transform.position + Vector3.left;
                break;
            default:
                destination = transform.position;
                break;
        }

        Vector3 desire = Vector3.Normalize(destination - transform.position) * 5 * Time.deltaTime;
        //Preventes desire values from being HUGE values
        desire = new Vector3(Mathf.Min(desire.x, 1), Mathf.Min(desire.y, 1), Mathf.Min(desire.z, 1));

        anim.SetBool("MOVE", true);
        while (Vector3.Distance(destination, transform.position) > .1f)
        {
            yield return null;

            transform.position += desire;
            //Prevents enemy from moving indefinitly, flying off the screen
            if(Vector3.Distance(destination, transform.position) > 1)
                transform.position = destination;
        }
        anim.SetBool("MOVE", false);
        transform.position = destination;

        GameStateMachine.enemyCount++;
    }
    
    public virtual void playerScan()
    {
        RaycastHit playerHit;
        playerInAttackRange = false;
        seenPlayer = false;


        for (float angle = 0; angle < 360; angle += 15)
        {

            //Debug.DrawRay(transform.position, new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(angle * Mathf.Deg2Rad)) * visionRange, Color.cyan, 2f);

            if (Physics.Raycast(transform.position, new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(angle * Mathf.Deg2Rad)), out playerHit, attackRange))
            {
                if (playerHit.transform.gameObject.tag == "Player" && angle % 90 == 0)
                {
                    playerLoc = playerHit.transform.position;
                    locReached = false;
                    //Debug.Log("PLAYER IN ATTACK RANGE");
                    playerInAttackRange = true;

                    //determines what direction the enemy is in
                    if (angle <= 45 || angle >= 315)
                    {
                        attackDirection = "up";
                        attackAngle = Quaternion.identity;
                    }
                    else if (angle <= 135)
                    {
                        attackDirection = "right";
                        attackAngle = Quaternion.identity;
                        attackAngle.eulerAngles = new Vector3(0, 90, 0);
                    }
                    else if (angle <= 225)
                    {
                        attackDirection = "down";
                        attackAngle = Quaternion.identity;
                        attackAngle.eulerAngles = new Vector3(0, 180, 0);
                    }
                    else if (angle <= 315)
                    {
                        attackDirection = "left";
                        attackAngle = Quaternion.identity;
                        attackAngle.eulerAngles = new Vector3(0, 270, 0);
                    }

                    Debug.Log(attackDirection);



                    seenPlayer = true;

                    break;
                }
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

    public virtual IEnumerator Chase()
    { 
        float x = playerLoc.x;
        float z = playerLoc.z;
        RaycastHit hit;

        bool right, left, up, down;
        right = left = up = down = true;

        Vector3 destination;
        if (Physics.Linecast(transform.position, transform.position + Vector3.right, out hit))
        {
            if (hit.transform.gameObject.tag == "Wall")
                right = false;
        }
        if (Physics.Linecast(transform.position, transform.position + Vector3.left, out hit))
        {
            if (hit.transform.gameObject.tag == "Wall" || hit.transform.gameObject.tag == "Player")
                left = false;
        }
        if (Physics.Linecast(transform.position, transform.position + Vector3.forward, out hit))
        {
            if (hit.transform.gameObject.tag == "Wall" || hit.transform.gameObject.tag == "Player")
                up = false;

        }
        if (Physics.Linecast(transform.position, transform.position + Vector3.back, out hit))
        {
            if (hit.transform.gameObject.tag == "Wall" || hit.transform.gameObject.tag == "Player")
                down = false;
        }

        
        if (Mathf.Abs(transform.position.x - x) > .01f)
        {


            if (transform.position.x < x && right)
            {
                destination = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                Vector3 desire = Vector3.Normalize(destination - transform.position) * 5 * Time.deltaTime;

                //Preventes desire values from being HUGE values
                desire = new Vector3(Mathf.Min(desire.x, 1), Mathf.Min(desire.y, 1), Mathf.Min(desire.z, 1));

                anim.SetBool("MOVE", true);
                while (Vector3.Distance(destination, transform.position) > .1f)
                {
                    yield return null;
                    transform.position += desire;

                    if (Vector3.Distance(destination, transform.position) > 1)
                        transform.position = destination;

                }
                transform.position = destination;
                anim.SetBool("MOVE", false);
                GameStateMachine.enemyCount++;
                yield break;
            }


            if (transform.position.x > x && left)
            {
                destination = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                Vector3 desire = Vector3.Normalize(destination - transform.position) * 5 * Time.deltaTime;

                //Preventes desire values from being HUGE values
                desire = new Vector3(Mathf.Min(desire.x, 1), Mathf.Min(desire.y, 1), Mathf.Min(desire.z, 1));

                anim.SetBool("MOVE", true);
                while (Vector3.Distance(destination, transform.position) > .1f)
                {
                    yield return null;
                    transform.position += desire;

                    if (Vector3.Distance(destination, transform.position) > 1)
                        transform.position = destination;
                }
                transform.position = destination;
                anim.SetBool("MOVE", false);
                GameStateMachine.enemyCount++;
                yield break;
            }
            if (!left && !right)
            {
                chasing = false;
            }


        }
        if (Mathf.Abs(transform.position.z - z) > .01f)
        {

            if (transform.position.z < z && up)
            {
                destination = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                Vector3 desire = Vector3.Normalize(destination - transform.position) * 5 * Time.deltaTime;

                //Preventes desire values from being HUGE values
                desire = new Vector3(Mathf.Min(desire.x, 1), Mathf.Min(desire.y, 1), Mathf.Min(desire.z, 1));

                anim.SetBool("MOVE", true);
                while (Vector3.Distance(destination, transform.position) > .1f)
                {
                    yield return null;
                    transform.position += desire;

                    if (Vector3.Distance(destination, transform.position) > 1)
                        transform.position = destination;

                }
                transform.position = destination;
                anim.SetBool("MOVE", false);
                GameStateMachine.enemyCount++;
                yield break;
            }

            if (transform.position.z > z && down)
            {
                destination = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                Vector3 desire = Vector3.Normalize(destination - transform.position) * 5 * Time.deltaTime;

                //Preventes desire values from being HUGE values
                desire = new Vector3(Mathf.Min(desire.x, 1), Mathf.Min(desire.y, 1), Mathf.Min(desire.z, 1));

                anim.SetBool("MOVE", true);
                while (Vector3.Distance(destination, transform.position) > .1f)
                {
                    yield return null;
                    transform.position += desire;

                    if (Vector3.Distance(destination, transform.position) > 1)
                        transform.position = destination;
                }
                transform.position = destination;
                anim.SetBool("MOVE", false);
                GameStateMachine.enemyCount++;
                yield break;
            }

            if (!up && !down)
            {              
                chasing = false;
            }
        }
        if (transform.position == playerLoc)
        {
            locReached = true;
            chasing = false;
        }
        else
        {
            GameStateMachine.enemyCount++;
            yield break;
        }

        yield return null;
    }

    //this became useless after I moved all of the Attacks to their child-classes
    /*public virtual void ChooseAttack()
    {
        Act1();
        GameStateMachine.enemyCount++;
    }*/

    public virtual void Act1()
    {   //1 Space in front hit 1 dmg

        inAttack = true;

        attackArray[0] = new Vector3(playerLoc.x, 0.05f, playerLoc.z);

        if (turnsWaiting == 0)
        {
            foreach (Vector3 a in attackArray)
            {
                Debug.Log("WARNING");
                GameObject b = Instantiate(attackWarning, playerLoc, Quaternion.identity, transform);
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
                //Debug.Log("Doot");

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

                        GameObject damageSound = x.GetComponent<PlayerScript>().DamagedSound;
                        if (damageSound != null)
                            GameObject.Instantiate(damageSound);

                        if (x.GetComponent<PlayerScript>().mystats.Health == 0)
                        {
                            ParticleSystem temp = Instantiate(x.GetComponent<PlayerScript>().playerKill, x.transform.position, Quaternion.Euler(90,0,0), x.gameObject.transform);
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
            Debug.Log("ATTACK!!!!!");
            inAttack = false;
            locReached = true;
            turnsWaiting = 0;
        }
    }

    //I moved all of these to their respective child-classes, but kept them here as comment Just In-Case(TM)
    /*public virtual void Act2()
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
                            ParticleSystem temp = Instantiate(x.GetComponent<PlayerScript>().playerKill, x.transform.position, Quaternion.identity, x.gameObject.transform);
                            Destroy(temp, temp.duration);
                        }
                        else
                        {
                            ParticleSystem temp = Instantiate(x.GetComponent<PlayerScript>().blood, x.transform.position, attackAngle, x.gameObject.transform);
                            Destroy(temp, temp.duration);
                        }
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


    }*/

    /* public virtual void Act3()
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
                        ScoreManager.damageTaken += dmg;
                        x.GetComponent<PlayerScript>().mystats.Damage(dmg);
                        if (x.GetComponent<PlayerScript>().mystats.Health == 0)
                        {
                            ParticleSystem temp = Instantiate(x.GetComponent<PlayerScript>().playerKill, x.transform.position, Quaternion.identity, x.gameObject.transform);
                            Destroy(temp, temp.duration);
                        }
                        else
                        {
                            ParticleSystem temp = Instantiate(x.GetComponent<PlayerScript>().blood, x.transform.position, attackAngle, x.gameObject.transform);
                            Destroy(temp, temp.duration);
                        }
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
    }*/

    /*public virtual void Act4()
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


                   if (dmg <= 0)
                            dmg = 1;
                        ScoreManager.damageTaken += dmg;
                        x.GetComponent<PlayerScript>().mystats.Damage(dmg);
                        if (x.GetComponent<PlayerScript>().mystats.Health == 0)
                        {
                            ParticleSystem temp = Instantiate(x.GetComponent<PlayerScript>().playerKill, x.transform.position, Quaternion.identity, x.gameObject.transform);
                            Destroy(temp, temp.duration);
                        }
                        else
                        {
                            ParticleSystem temp = Instantiate(x.GetComponent<PlayerScript>().blood, x.transform.position, attackAngle, x.gameObject.transform);
                            Destroy(temp, temp.duration);
                        }
                        x.GetComponent<PlayerScript>().myUi.UpdateCurrentHealth();
                    }
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
        
    }*/

    /*public virtual void Act5()
    {
        //ranged attack
        inAttack = true;
        attackArray[0] = new Vector3(playerLoc.x, .05f, playerLoc.z);
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
                        Debug.Log("enemy str" + stats.Strength);
                        Debug.Log("player def" + x.GetComponent<PlayerScript>().mystats.Defense);
                        if (dmg <= 0)
                        {
                            dmg = 1;
                            ScoreManager.damageTaken += dmg;
                        }
                        x.GetComponent<PlayerScript>().mystats.Damage(dmg);
                        if (x.GetComponent<PlayerScript>().mystats.Health == 0)
                        {
                            ParticleSystem temp = Instantiate(x.GetComponent<PlayerScript>().playerKill, x.transform.position, Quaternion.identity, x.gameObject.transform);
                            Destroy(temp, temp.duration);
                        }
                        else
                        {
                            ParticleSystem temp = Instantiate(x.GetComponent<PlayerScript>().blood, x.transform.position, attackAngle, x.gameObject.transform);
                            Destroy(temp, temp.duration);
                        }
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
    }*/

    /*public virtual IEnumerator chargeMove(int newDes)
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
    }*/
}
