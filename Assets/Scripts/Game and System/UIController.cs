using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {


    [SerializeField]
    public Sprite[] Inputs;

    public int input;

    [SerializeField]
    Sprite Default;

    [HideInInspector]
    public Image currentInput;
    

	// Use this for initialization
	void Start () {
        input = 0;
        currentInput = GetComponent<Image>();

		
	}
	
	// Update is called once per frame
	void Update () {

        if(input > 0)
        {
            currentInput.sprite = Inputs[input - 1];
        }
        else
        {
            currentInput.sprite = Default;
            
        }
		
	}
}
