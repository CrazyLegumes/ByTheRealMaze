using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLighting : MonoBehaviour {


    class Points
    {
        GameObject obj;
        Vector3 endpoints;
        Vector3 hitpoint;
        //[Range(0, 360)]
        float angle;
        
    }

    Points[] collection;
    

    void Awake()
    {
        
        for(int angle = 0; angle < 360; angle += 30)
        {

        }
    }
  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
