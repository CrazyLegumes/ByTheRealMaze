using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObject : MonoBehaviour {

    public float Delay = 5;

	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, Delay);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
