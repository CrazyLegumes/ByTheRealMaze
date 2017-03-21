using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseEnemy : MonoBehaviour
{

    //public enum Enemytype
    //{
    //    small,
    //    medium,
    //    large,
    //    boss
    //}

    protected StatsClass stats;
    //Enemytype type;
    protected string enemyName;
    protected GameObject attackWarning;
    protected int windup = 1;
    protected int attackSize = 1;
    protected float visionRange = 3;
    protected float attackRange = 1;
    protected Vector3[] attackArray;
    public bool seenPlayer;
    public bool locReached;
    public bool chasing;
    public bool inAttack;
    public bool playerInAttackRange;
    public Vector3 playerLoc;
    public LayerMask HitMask;

    private int turnsWaiting = 0;

    public virtual void initialize()
    {
        attackArray = new Vector3[attackSize];
        attackWarning = (GameObject)Resources.Load("Prefabs/AttackWarning", typeof(GameObject));
        chasing = false;
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

    //public Enemytype Type
    //{
    //    get
    //    {
    //        return typ;e
    //    }

    //    set
    //    {
    //        type = value;
    //    }
    //}

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





    // Possible Max of 6 actions and move. //Or can be set for each enemy instead of defining them here 
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
                Debug.Log("wall above");
                up = false;
            }
        if (Physics.Linecast(transform.position, transform.position + Vector3.back, out RC))
            if (RC.transform.gameObject.tag == "Wall")
            {
                Debug.Log("wall below");
                down = false;
            }
        if (Physics.Linecast(transform.position, transform.position + Vector3.right, out RC))
            if (RC.transform.gameObject.tag == "Wall")
            {
                Debug.Log("wall right");
                right = false;
            }
        if (Physics.Linecast(transform.position, transform.position + Vector3.left, out RC))
            if (RC.transform.gameObject.tag == "Wall")
            {
                Debug.Log("wall left");
                left = false;
            }

        int randMove = 0;
        while (true)
        {
            yield return null;
            randMove = Random.Range(1, 5);
            //Debug.Log(randMove + " is the direction");
            if (up == false && randMove == 1)
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
        }

        while (transform.position != destination)
        {
            yield return null;
            transform.position = Vector3.Lerp(transform.position, destination, 10 * Time.deltaTime);
        }

        GameStateMachine.enemyCount++;
    }

    public virtual void playerScan()
    {
        RaycastHit playerHit;
        playerInAttackRange = false;
        seenPlayer = false;


        for (float angle = 0; angle < 360; angle += 15)
        {

            Debug.DrawRay(transform.position, new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(angle * Mathf.Deg2Rad)) * 2f, Color.red, 5f);

            if (Physics.Raycast(transform.position, new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(angle * Mathf.Deg2Rad)), out playerHit, attackRange))
                if (playerHit.transform.gameObject.tag == "Player")
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
            if (hit.transform.gameObject.tag == "Wall")
                left = false;
        }
        if (Physics.Linecast(transform.position, transform.position + Vector3.up, out hit))
        {
            if (hit.transform.gameObject.tag == "Wall")
                up = false;
        }
        if (Physics.Linecast(transform.position, transform.position + Vector3.down, out hit))
        {
            if (hit.transform.gameObject.tag == "Wall")
                down = false;
        }
        if (Mathf.Abs(transform.position.x - x) > .01f)
        {


            if (transform.position.x < x && right)
            {
                Debug.Log("Enemy moving right");
                destination = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                while (transform.position != destination)
                {
                    yield return null;
                    transform.position = Vector3.Lerp(transform.position, destination, 10 * Time.deltaTime);
                }
                GameStateMachine.enemyCount++;
                yield break;
            }


            if (transform.position.x > x && left)
            {
                Debug.Log("Enemy moving left");
                destination = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                while (transform.position != destination)
                {
                    yield return null;
                    transform.position = Vector3.Lerp(transform.position, destination, 10 * Time.deltaTime);
                }
                GameStateMachine.enemyCount++;
                yield break;
            }


        }
        if (Mathf.Abs(transform.position.z - z) > .01f)
        {

            if (transform.position.z < z && up)
            {
                Debug.Log("Enemy moving up");
                destination = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                while (transform.position != destination)
                {
                    yield return null;
                    transform.position = Vector3.Lerp(transform.position, destination, 10 * Time.deltaTime);
                }
                GameStateMachine.enemyCount++;
                yield break;
            }

            if (transform.position.z > z && down)
            {
                Debug.Log("Enemy moving down");
                destination = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                while (transform.position != destination)
                {
                    yield return null;
                    transform.position = Vector3.Lerp(transform.position, destination, 10 * Time.deltaTime);
                }
                GameStateMachine.enemyCount++;
                yield break;
            }
        }
        if (transform.position == playerLoc)
        {

            locReached = true;
            chasing = false;
        }


        yield return null;
    }

    public virtual void ChooseAttack()
    {
        Act1();
        GameStateMachine.enemyCount++;
    }

    public virtual void Act1()
    {        //1 Turn Windup 1 Space hit

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
                Debug.Log("Doot");

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
            Debug.Log("ATTACK!!!!!");
            inAttack = false;
            locReached = true;
            turnsWaiting = 0;
        }
    }
    public virtual void Act2() { }
    public virtual void Act3() { }
    public virtual void Act4() { }
    public virtual void Act5() { }
}
