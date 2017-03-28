using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public static int menuState = 1;
    public static int cursor = 1;

    public Camera mainCam;
    public Camera helpCam;
    public Camera creditCam;
    public Text selection;


	// Use this for initialization
	void Start () {
        mainCam.enabled = true;
        helpCam.enabled = false;
        creditCam.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        camUpdate();
        selectionUpdate();

        if (menuState == 1)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                cursor -= 1;
                if (cursor < 1)
                {
                    cursor = 4;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                cursor += 1;
                if (cursor > 4)
                {
                    cursor = 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (cursor == 1)
                {
                    SceneManager.LoadScene(1);
                }
                if (cursor == 2) 
                {
                    menuState = 2;
                }
                if (cursor == 3)
                {
                    menuState = 3;
                }
                if (cursor == 4)
                {
                    Application.Quit();
                }
            }
        }

        if (menuState == 2 || menuState == 3)
        {
            if (Input.GetKeyDown(KeyCode.Escape)){
                menuState = 1;
                cursor = 1;
            }
        }


	}

    void camUpdate()
    {
        if (menuState == 1)
        {
            mainCam.enabled = true;
            helpCam.enabled = false;
            creditCam.enabled = false;
        }
        if (menuState == 2)
        {
            mainCam.enabled = false;
            helpCam.enabled = true;
            creditCam.enabled = false;
        }
        if (menuState == 3)
        {
            mainCam.enabled = false;
            helpCam.enabled = false;
            creditCam.enabled = true;
        }
    }

    void selectionUpdate()
    {
        if (cursor == 1)
        {
            selection.text = "<START GAME>";
        }
        if (cursor == 2)
        {
            selection.text = "<HELP>";
        }
        if (cursor == 3)
        {
            selection.text = "<CREDITS>";
        }
        if (cursor == 4)
        {
            selection.text = "<EXIT>";
        }
    }
}
