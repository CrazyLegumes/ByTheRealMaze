using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : GameState {


    public override void Enter()
    {
        base.Enter();
        StartCoroutine(MovePlayer1());
        //StartCoroutine(MovePlayer2());
        //StartCoroutine(MovePlayer3());
        //StartCoroutine(MovePlayer4());
    }


    IEnumerator MovePlayer1()
    {
        Vector3 destination = P1.transform.position;
        yield return new WaitForSeconds(1);
        RaycastHit hit = new RaycastHit();
        Debug.Log("Moving to " + gameController.moveinput1.ToString());
       
        switch (gameController.moveinput1)
        {
            case GameStateMachine.Inputs.movedown:
                destination = P1.transform.position + new Vector3(0, 0, -1);
                break;

            case GameStateMachine.Inputs.moveleft:
                destination = P1.transform.position + new Vector3(-1, 0, 0);
                break;

            case GameStateMachine.Inputs.moveright:
               destination = P1.transform.position + new Vector3(1, 0, 0);
                break;

            case GameStateMachine.Inputs.moveup:
                destination = P1.transform.position + new Vector3(0, 0, 1);
                break;
            case GameStateMachine.Inputs.none:
                break;
        }
        Debug.DrawRay(P1.transform.position, destination, Color.red,4);
        yield return new WaitForSeconds(2);
        

        while (P1.transform.position != destination)
        {
            P1.transform.position = Vector3.Lerp(P1.transform.position, destination, 10 * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        gameController.ChangeState<InputState>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
