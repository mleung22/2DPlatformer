using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

    public static float timer = 100.07f;
    public GameObject gameOverScreen;
    public bool increaseTime;
    Text scoreValue;
    private Player player;
 
	// Use this for initialization
	void Start () {
        scoreValue = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        increaseTime = true;

    }
	
	// Update is called once per frame
	void Update () {

        if (increaseTime == true)
        {
            timer -= Time.deltaTime;
            scoreValue.text = "Timer: " + (int)timer;

        }
        

        if (timer <= 0)
        {
            gameOverScreen.SetActive(true);
            timer = 0;
            scoreValue.text = "Timer: Out Of Time";
            player.currentHealth = 0;
        }

        if (player == null)
        {
            player.checkDeath();
            increaseTime = false;
        }
        

       

        
	}
}
