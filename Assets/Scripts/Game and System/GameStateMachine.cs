using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : StateMachine {

    public float timeStep;
   public static  GameStateMachine instance;

    
	//StateMachine for The Game Could be used for menues or not.
    
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
        }
        //instance.ChangeState<>();
    }
 








}
