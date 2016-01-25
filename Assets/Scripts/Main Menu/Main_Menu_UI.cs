using UnityEngine;
using System.Collections;

public class Main_Menu_UI : MonoBehaviour {

    public GameObject panel;
    public int stage;
	// Use this for initialization
	
    public void StartGame()
    {
        Application.LoadLevel(stage);
        Timer.timer = 100.07f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
