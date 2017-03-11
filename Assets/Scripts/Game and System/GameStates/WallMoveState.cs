using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoveState : GameState {

    public override void Enter()
    {
        int count = gameController.wallList.Count;
        int i = Random.Range(0, count);
        int j = Random.Range(0, count);

        StartCoroutine(init());
    }

    IEnumerator init()
    {
        yield return new WaitForSeconds(2f);
        gameController.ChangeState<InputState>();
        Debug.Log(gameController.currstate);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
