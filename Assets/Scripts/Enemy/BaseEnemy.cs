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
    protected int windup = 0;

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

    public virtual void Act1() {        //1 Turn Windup 1 Space hit

    }
    public virtual void Act2() { }
    public virtual void Act3() { }
    public virtual void Act4() { }
    public virtual void Act5() { }
}
