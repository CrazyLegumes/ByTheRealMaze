using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditManager : MonoBehaviour {

    private GameObject scores;

    [SerializeField]
    public Text damage;
    [SerializeField]
    public Text turns;
    [SerializeField]
    public Text killed;

    // Use this for initialization
    void Awake () {
        scores = GameObject.Find("ScoreManager");
	}

    void Start()
    {
        killed.text = ScoreManager.enemiesKilled + "";
        turns.text = ScoreManager.turnsTaken + "";
        damage.text = ScoreManager.damageTaken + "";
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(scores);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
