using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Username_Enter : MonoBehaviour {

    public GameObject UI;
    public GameObject gameOverUI;
    public Text NameTag;
    public InputField _userInput;
    public static string username;


    // Use this for initialization

    void Start()
    {  
        UI.SetActive(true);
    }
	void FixedUpdate () {
        Time.timeScale = 0;

    }
	

    public void Go()
    {
        UI.SetActive(false);
        username = _userInput.text;
        NameTag.text = "Player: " + username;
        


    }


}
