using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_HealthBar : MonoBehaviour {

    public Sprite[] healthSprites;
    public Image showedSprite;

    private Player player;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	    
        if (player.currentHealth < 0)
        {
            player.currentHealth = 0;
        }

        showedSprite.sprite = healthSprites[player.currentHealth];
	}
}
