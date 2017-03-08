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
            GrabInput();
            if (currentTimer >= gameController.timeStep)
                timesUp = true;
        }
        if (timesUp)
            BeginChange();
    }


    void BeginChange()
    {
       // gameController.ChangeState<MoveState>();
    }

    void GrabInput()
    {
        Input.
    }

}
