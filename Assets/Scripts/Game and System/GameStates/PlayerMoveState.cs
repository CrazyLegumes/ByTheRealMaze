using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : GameState
{
    LayerMask wallMask;

    public override void Enter()
    {
        wallMask = LayerMask.NameToLayer("Wall");
        base.Enter();
        StartCoroutine(MovePlayer1());
        //StartCoroutine(MovePlayer2());
        //StartCoroutine(MovePlayer3());
        //StartCoroutine(MovePlayer4());
    }


    IEnumerator MovePlayer1()
    {
        Vector3 destination = P1.transform.position;
        yield return new WaitForEndOfFrame();
        RaycastHit hit = new RaycastHit();

        switch (gameController.moveinput1)
        {
            case GameStateMachine.Inputs.Down:
                destination = P1.transform.position + new Vector3(0, 0, -1);
                break;

            case GameStateMachine.Inputs.Left:
                destination = P1.transform.position + new Vector3(-1, 0, 0);
                break;

            case GameStateMachine.Inputs.Right:
                destination = P1.transform.position + new Vector3(1, 0, 0);
                break;

            case GameStateMachine.Inputs.Up:
                destination = P1.transform.position + new Vector3(0, 0, 1);
                break;

            case GameStateMachine.Inputs.useitem:
                if (P1.Item1 != null)
                {
                    Debug.Log("Use Item 1: " + P1.Item1.name);
                    P1.Item1.Use();
                }

                break;
            case GameStateMachine.Inputs.None:
                break;

        }



        /*
                Debug.DrawLine(P1.transform.position, P1.transform.position + Vector3.forward, Color.red, 3);
                Debug.DrawLine(P1.transform.position, P1.transform.position + Vector3.left, Color.red, 3);
                Debug.DrawLine(P1.transform.position, P1.transform.position + Vector3.right, Color.red, 3);
                Debug.DrawLine(P1.transform.position, P1.transform.position + Vector3.back, Color.red, 3);
                */

        Debug.DrawLine(P1.transform.position, destination, Color.red, 3);
        if (Physics.Linecast(P1.transform.position, destination, out hit))
        {

            if (hit.transform.gameObject.tag == "Wall") //And movable wall check
            {
                Debug.Log(hit.transform.name);

                gameController.ChangeState<EnemyMoveState>();
                yield break;
            }

            if (hit.transform.gameObject.tag == "Enemy")
            {
                int dmg = gameController.player1.GetComponent<PlayerScript>().mystats.Strength - hit.transform.gameObject.GetComponent<BaseEnemy>().Stats.Defense;
                if (dmg <= 0)
                    dmg = 1;
                hit.transform.gameObject.GetComponent<BaseEnemy>().Stats.Damage(dmg);
                if (hit.transform.gameObject.GetComponent<BaseEnemy>().Stats.Health == 0)
                {
                    gameController.enemyList.Remove(hit.transform.gameObject.GetComponent<BaseEnemy>());
                    GameObject.Destroy(hit.transform.gameObject);
                }


                gameController.ChangeState<EnemyMoveState>();
                yield break;
            }
        }




        while (P1.transform.position != destination)
        {
            yield return null;
            P1.transform.position = Vector3.Lerp(P1.transform.position, destination, 15 * Time.deltaTime);
        }
        //StartCoroutine(P1.GetComponent<LightingShadows>().SweepArea());

        //yield return new WaitForSeconds(.5f);


        if (GameStateMachine.won == true)       //WON THE GAME
        {
            Time.timeScale = 0;
        }

        // yield return new WaitForEndOfFrame();
        if (gameController.itemToDrop != null)
        {
            gameController.itemToDrop.Dropped = true;
            gameController.itemToDrop.transform.parent.position = P1.transform.position;
            gameController.itemToDrop.GetComponent<Renderer>().enabled = true;
            gameController.itemToDrop.GetComponent<Collider>().enabled = true;
            gameController.itemToDrop = null;

        }
        gameController.ChangeState<EnemyMoveState>();

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
