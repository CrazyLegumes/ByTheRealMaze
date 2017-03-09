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
        if (Physics.Linecast(P1.transform.position, destination,out hit))
        {
            Debug.Log(hit.transform.name);
            Debug.Log("Hit Cant Move");
            gameController.ChangeState<InputState>();
            yield break;
        }




        while(P1.transform.position != destination)
        {
            yield return null;
            P1.transform.position = Vector3.Lerp(P1.transform.position, destination, 10 * Time.deltaTime);
        }
        yield return new WaitForSeconds(.5f);
        gameController.ChangeState<InputState>();

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
