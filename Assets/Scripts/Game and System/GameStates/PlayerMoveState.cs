using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public delegate void OnTurnEnd();
public class PlayerMoveState : GameState {

    LayerMask wallMask;
    [SerializeField]
    LayerMask layers;
    LayerMask EnemyMask;

    public override void Enter()
    {
        ScoreManager.turnsTaken++;
        wallMask = LayerMask.NameToLayer("Wall");
        EnemyMask = LayerMask.NameToLayer("Enemy");
        layers += wallMask;
        layers += EnemyMask;
        base.Enter();
        StartCoroutine(MovePlayer1());
        
        //StartCoroutine(MovePlayer2());
        //StartCoroutine(MovePlayer3());
        //StartCoroutine(MovePlayer4());
    }


    IEnumerator MovePlayer1()
    {

        Vector3 destination = P1.transform.position;
        Quaternion attackAngle = Quaternion.identity;
        yield return new WaitForEndOfFrame();
        RaycastHit hit = new RaycastHit();
        Debug.Log("Moving to " + gameController.moveinput1.ToString());

        if (P1.useItem)
        {
            if (P1.Item1 != null)
            {
                Debug.Log("Use Item 1: " + P1.Item1.name);
                P1.Item1.Use();
            }
            gameController.moveinput1 = GameStateMachine.Inputs.None;
            P1.useItem = false;

        }



        switch (gameController.moveinput1)
        {
            case GameStateMachine.Inputs.Down:
                destination = P1.transform.position + new Vector3(0, 0, -1);
                attackAngle.eulerAngles = new Vector3(0, 180, 0);
                break;

            case GameStateMachine.Inputs.Left:
                destination = P1.transform.position + new Vector3(-1, 0, 0);
                attackAngle.eulerAngles = new Vector3(0, 270, 0);
                break;

            case GameStateMachine.Inputs.Right:
                destination = P1.transform.position + new Vector3(1, 0, 0);

                attackAngle.eulerAngles = new Vector3(0, 90, 0);

                break;

            case GameStateMachine.Inputs.Up:
                destination = P1.transform.position + new Vector3(0, 0, 1);
                attackAngle.eulerAngles = new Vector3(0, 0, 0);
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
Move:
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
                    GameObject attackSound = gameController.player1.GetComponent<PlayerScript>().AttackSound;

                    if(attackSound != null)
                        GameObject.Instantiate(attackSound);

                    ParticleSystem blood = gameController.player1.GetComponent<PlayerScript>().enemyKill;
                    ParticleSystem temp = Instantiate(blood, hit.transform.position, Quaternion.identity);
                    Destroy(temp, temp.duration);
                    ScoreManager.enemiesKilled++;
                    gameController.enemyList.Remove(hit.transform.gameObject.GetComponent<BaseEnemy>());
                    GameObject.Destroy(hit.transform.gameObject);
                }


                else
                {
                    ParticleSystem blood = gameController.player1.GetComponent<PlayerScript>().blood;
                    ParticleSystem temp = Instantiate(blood, hit.transform.position, attackAngle);
                    Destroy(temp, temp.duration);
                }


                gameController.ChangeState<EnemyMoveState>();
                yield break;
            }
        }


        Vector3 desire = Vector3.Normalize(destination - P1.transform.position) * 5 * Time.deltaTime;
        //Preventes desire values from being HUGE values
        desire = new Vector3(Mathf.Min(desire.x, 1), Mathf.Min(desire.y, 1), Mathf.Min(desire.z, 1));

        P1.anim.SetBool("Jump", true);
        while (Vector3.Distance(destination, P1.transform.position) > .1f)
        {
            
            yield return null;
            P1.transform.position += desire;

            if (Vector3.Distance(destination, P1.transform.position) > 1)
                P1.transform.position = destination;
        }
        P1.transform.position = destination;
        P1.anim.SetBool("Jump", false);
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

        if (P1.myDel != null)
            P1.myDel();



        P1.myUi.UpdateCurrentHealth();
        yield return new WaitForSeconds(.2f);
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
