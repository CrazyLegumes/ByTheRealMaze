using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : StateMachine {

    public enum Inputs
    {
        none,
        moveleft,
        moveright,
        moveup,
        movedown,
        switchitem,
        useitem
    }
    public float timeStep;
    public GameObject player1;
    public static  GameStateMachine instance;
    public Inputs moveinput1;
    public Inputs actioninput1;


    //StateMachine for The Game Could be used for menues or not.

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
        }
        ChangeState<InputState>();
    }
 








}
