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
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Wall")
            Destroy(gameObject);

        if (col.tag == "Enemy")
        {
            BaseEnemy em = col.GetComponent<BaseEnemy>();

            em.Stats.Damage(5);
            
        }
    }
}
