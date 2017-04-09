using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : BaseEnemy {


    public override IEnumerator Move()
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
            default:
                destination = transform.position;
                break;
        }

        while (transform.position != destination)
        {
            yield return null;
            transform.position = Vector3.Lerp(transform.position, destination, 10 * Time.deltaTime);
        }

        GameStateMachine.enemyCount++;
        //StartCoroutine(base.Move());    //if player not seen
        yield return null;
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


    void Start () {
        windup = 1;
        InitStats();
        attackSize = 1;
        attackRange = 4;
        visionRange = 6;
        base.initialize();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
