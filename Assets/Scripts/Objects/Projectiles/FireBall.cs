using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Projectile {
    public Vector3 velocity;

    
    void OnTriggerEnter(Collider col)
    {
        
        
    }

    void OnDestroy()
    {
        GameStateMachine.instance.spellCount--;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Wall")
        {
            
            Destroy(gameObject);
        }

        if (col.collider.tag == "Enemy")
        {
            BaseEnemy em = col.collider.GetComponent<BaseEnemy>();

            em.Stats.Damage(5);
            
            Destroy(gameObject);
            
        }
        
    }

    // Use this for initialization
    void Start () {
       
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 des = transform.position + velocity;
        Vector3 target = Vector3.Normalize(des - transform.position);
        transform.position += target * 7 *  Time.deltaTime;
		
	}
}
