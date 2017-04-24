using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public Camera main;
    public Camera credits;
    public Camera help;
    public GameObject cursor;
    private int state;
    private Image img;
    private int selection;

    // Use this for initialization
    void Start()
    {
        Resources.UnloadUnusedAssets();
        Time.timeScale = 1;
        state = 1;
        selection = 1;
        img = cursor.GetComponentInChildren<Image>();
        main.enabled = true;
        credits.enabled = false;
        help.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 1)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (selection == 1)
                    SceneManager.LoadScene(1, LoadSceneMode.Single);
                if (selection == 2)
                {
                    main.enabled = false;
                    help.enabled = true;
                    state = 2;
                }
                if (selection == 3)
                {
                    main.enabled = false;
                    credits.enabled = true;
                    state = 3;
                }
                if (selection == 4)
                {
                    Application.Quit();
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selection--;
                if (selection < 1)
                    selection = 4;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selection++;
                if (selection > 4)
                    selection = 1;
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
                selection = 1;
            }
        }

        moveCursor();
    }

    void moveCursor()
    {
        if (selection == 1)
        {
            cursor.transform.localPosition = new Vector3(-300, -19, 0);
        }
        if (selection == 2)
        {
            cursor.transform.localPosition = new Vector3(-300, -128, 0);
        }
        if (selection == 3)
        {
            cursor.transform.localPosition = new Vector3(-300, -241, 0);
        }
        if (selection == 4)
        {
            cursor.transform.localPosition = new Vector3(-300, -353, 0);
        }
    }
}
