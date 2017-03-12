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
            P1.activeItem = !P1.activeItem;
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
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
               
                gameController.moveinput1 = GameStateMachine.Inputs.Down;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                
                gameController.moveinput1 = GameStateMachine.Inputs.Right;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                
                gameController.moveinput1 = GameStateMachine.Inputs.Left;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                gameController.moveinput1 = GameStateMachine.Inputs.useitem;
            }
        }
    }

}
