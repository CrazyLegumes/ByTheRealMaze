using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : GameState {
    float currentTimer;
    bool counting = false;
    bool timesUp;

    public override void Enter()
    {
        base.Enter();
        currentTimer = 0f;
        timesUp = false;
        counting = true; //start the timer
        gameController.moveinput1 = GameStateMachine.Inputs.none;
        
    }

    public override void Exit()
    {
        base.Exit();
        counting = false;
    }

    void Update()
    {
        if (counting)
        {
            currentTimer += Time.deltaTime;
            //Debug.Log(currentTimer);
          
            GrabMoveInput();
            if (currentTimer >= gameController.timeStep)
                timesUp = true;
        }
        if (timesUp)
            BeginChange();
    }


    void BeginChange()
    {
        gameController.ChangeState<PlayerMoveState>();
    }

    void GrabMoveInput()
    {
        if (!timesUp)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("UP");
                gameController.moveinput1 = GameStateMachine.Inputs.moveup;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("DOWN");
                gameController.moveinput1 = GameStateMachine.Inputs.movedown;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("RIGHT");
                gameController.moveinput1 = GameStateMachine.Inputs.moveright;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("LEFT");
                gameController.moveinput1 = GameStateMachine.Inputs.moveleft;
            }
        }
    }

}
