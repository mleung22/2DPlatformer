using UnityEngine;
using System.Collections;

public class Game_Over : MonoBehaviour {

    private Player player;
    public GameObject UI;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        UI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {       
        if (player == null)
        {
            UI.SetActive(true);

            Time.timeScale = 0;
        }
	}

 




}
