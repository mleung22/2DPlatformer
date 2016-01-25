using UnityEngine;
using System.Collections;

public class Pause_Menu : MonoBehaviour {

    public GameObject UI;
    public GameObject Ue;
    private bool isPaused = false;

	// Use this for initialization
	void Start () {
        UI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    
        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            UI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!isPaused)
        {
            UI.SetActive(false);
            if (!Ue.activeSelf)
            {
                Time.timeScale = 1;
            }
            
        }
	}

    public void Resume()
    {
        isPaused = false;
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Timer.timer = 100.07f;
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
