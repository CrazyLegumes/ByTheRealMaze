using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameStateMachine : StateMachine {

    public enum Inputs
    {
        None,
        Left,
        Right,
        Up,
        Down,
        
        useitem
    }
    public float timeStep;
    public GameObject player1;
    public static  GameStateMachine instance;
    public Inputs moveinput1;
    public Inputs actioninput1;
    public float currentTimer;
    public Slider timer;
    public Text input;
    public string currstate;
    public List<BaseEnemy> enemyList;
    public List<GameObject> wallList;
    
    


   
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
 

    void Update()
    {
        timer.value = currentTimer;
        input.text = moveinput1.ToString();
        currstate = _currentState.ToString();
    }






}
