using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : GameState {
   
    bool counting = false;
    bool timesUp;

    public override void Enter()
    {
        base.Enter();
        gameController.currentTimer = gameController.timeStep;
        timesUp = false;
        counting = true; //start the timer
        gameController.moveinput1 = GameStateMachine.Inputs.None;
        gameController.player1.GetComponent<PlayerScript>().useItem = false;
        
    }

    public override void Exit()
    {
        base.Exit();
        gameController.currentTimer = 0;
        counting = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            P1.SwapItems();
        }
        if (counting)
        {
            gameController.currentTimer -= Time.deltaTime;
            //Debug.Log(currentTimer);
          
            GrabMoveInput();
            if (gameController.currentTimer <= 0)
                timesUp = true;
        }
        if (timesUp)
            BeginChange();
    }


    void BeginChange()
    {
        timesUp = false;
        gameController.ChangeState<PlayerMoveState>();
        Debug.Log(gameController.currstate);
    }

    void GrabMoveInput()
    {
        if (!timesUp)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                gameController.moveinput1 = GameStateMachine.Inputs.Up;
                gameController.player1.GetComponent<PlayerScript>().dir = "North";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
               
                gameController.moveinput1 = GameStateMachine.Inputs.Down;
                gameController.player1.GetComponent<PlayerScript>().dir = "South";
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                
                gameController.moveinput1 = GameStateMachine.Inputs.Right;
                gameController.player1.GetComponent<PlayerScript>().dir = "East";
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                
                gameController.moveinput1 = GameStateMachine.Inputs.Left;
                gameController.player1.GetComponent<PlayerScript>().dir = "West";
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                gameController.player1.GetComponent<PlayerScript>().useItem = !gameController.player1.GetComponent<PlayerScript>().useItem;
            }
        }
    }

}
