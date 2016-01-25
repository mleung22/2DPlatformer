using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
           StartCoroutine(player.damage(1));
           
           player.knockBack(0.5f, -90, player.transform.position);

           
        }
    }

    
}
