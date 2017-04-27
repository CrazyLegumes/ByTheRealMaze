using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        GameStateMachine.instance.spellCount--;
    }
    void OnCollisionEnter(Collision col)
    {
        

        if (col.collider.tag == "Enemy")
        {
            BaseEnemy em = col.collider.GetComponent<BaseEnemy>();

            em.Stats.Damage(3);
            
        }
    }


   
}
