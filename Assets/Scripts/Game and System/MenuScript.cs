using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Camera main;
    public Camera credits;
    public Camera help;
    private int state;

	// Use this for initialization
	void Start () {
        Resources.UnloadUnusedAssets();
        state = 1;
        main.enabled = true;
        credits.enabled = false;
        help.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (state == 1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                main.enabled = false;
                help.enabled = true;
                state = 2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                main.enabled = false;
                credits.enabled = true;
                state = 3;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Application.Quit();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                main.enabled = true;
                help.enabled = false;
                credits.enabled = false;
                state = 1;
            }
        }
	}
}
