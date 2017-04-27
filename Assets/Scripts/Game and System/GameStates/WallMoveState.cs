using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoveState : GameState {

    public override void Enter()
    {
        
        

        
        StartCoroutine(init());
    }

    IEnumerator init()
    {
        bool started = true;
        foreach (MovableWalls a in gameController.movableWalls)
        {



            StartCoroutine(a.MoveWall());
            


        }
        started = false;


        yield return new WaitForEndOfFrame();
        gameController.ChangeState<InputState>();
        yield break;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
