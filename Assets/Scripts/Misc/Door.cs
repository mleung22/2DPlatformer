using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    public int stage;
    public GameObject leaderboard;
    private Player player;
    private bool playerArrived = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        playerArrived = true;
        
    }

    void Update()
    {

        if (playerArrived)
        {
            if (Input.GetButtonDown("Enter"))
            {
                player.currentHealth = 0;
                leaderboard.SetActive(true);
                LeaderBoard.AddNewHighscore(Username_Enter.username, (int)Timer.timer);
            }
        }
    }
 
        

    
}
