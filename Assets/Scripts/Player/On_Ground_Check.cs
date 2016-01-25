using UnityEngine;
using System.Collections;

public class On_Ground_Check : MonoBehaviour {

    private Player player;


	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInParent<Player>();    
	}

	
	void OnTriggerEnter2D(Collider2D c)
    {
        if (player != null)
        {
            player.onGround = true;

            // Can stand on platform
            if (c.gameObject.tag == "Grass Step Collider")
            {
                c.transform.GetComponent<Collider2D>().isTrigger = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        player.onGround = true;
        if (c.gameObject.tag == "Grass Step Collider")
        {
            if (Input.GetButtonDown("Down"))
            {
                c.transform.GetComponent<Collider2D>().isTrigger = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D c)
    {
        player.onGround = false;

        // Can pass through platform when player is not on it
        if (c.gameObject.tag == "Grass Step Collider")
        {
            c.transform.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
