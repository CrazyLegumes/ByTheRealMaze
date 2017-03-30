using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Image Timer2;
    public Text input;
    public string currstate;
    public List<BaseEnemy> enemyList;
    public List<MovableWalls> movableWalls;

    [SerializeField]
    public Canvas done;

    [SerializeField]
    public Text overState;

    public static bool won;
    public static bool over;
    public static int enemyCount = 0;
    Color startColor;
    
    


   
    //StateMachine for The Game Could be used for menues or not.

    void Awake()
    {
        done.enabled = false;
        won = false;
        over = false;

        startColor = Timer2.color;
        if (instance != null)
            Destroy(gameObject);
        
        else
        {
            instance = this;
        }
        foreach(GameObject a in GameObject.FindGameObjectsWithTag("Wall"))
        {
            if (a.GetComponent<MovableWalls>() != null)
                movableWalls.Add(a.GetComponent<MovableWalls>());
        }

    }
 

    void Update()
    {
        //timer.value = currentTimer;
        over = player1.GetComponent<PlayerScript>().mystats.Dead;
        gameOver();
        input.text = moveinput1.ToString();
        currstate = _currentState.ToString();
        Timer2.fillAmount = currentTimer / timeStep;
        if (Timer2.fillAmount > .5f)
            Timer2.CrossFadeColor(startColor, .00001f, false, false);
        if (Timer2.fillAmount < .5f && Timer2.fillAmount > .2f)
        {
            Timer2.CrossFadeColor(new Color(5,5,0, 1), 1f, false, false);
        }
        if (Timer2.fillAmount < .2f)
        {
            
            Timer2.CrossFadeColor(new Color(255, 0, 0, 1), .1f, false, false);
        }
        
    }

    void Start()
    {
        foreach (BaseEnemy a in enemyList)
        {
            a.initialize();
        }

        ChangeState<InputState>();
    }

    void gameOver()
    {
        
        if (over == true)
        {
            done.enabled = true;
            if (Input.GetKeyDown(KeyCode.Return)){
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
            overState.text = "GAME OVER!";
        }
        if (won == true)
        {
            done.enabled = true;
            if (Input.GetKeyDown(KeyCode.Return)){
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
            overState.text = "YOU WON!";
        }
    }
}
