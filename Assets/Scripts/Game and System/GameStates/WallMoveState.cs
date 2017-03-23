using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoveState : GameState {

    public override void Enter()
    {
        foreach (MovableWalls a in gameController.movableWalls)
        {
            StartCoroutine(a.MoveWall());
        }

        StartCoroutine(init());
    }

    IEnumerator init()
    {
        yield return new WaitForEndOfFrame();
        gameController.ChangeState<InputState>();
        Debug.Log(gameController.currstate);
        yield break;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
