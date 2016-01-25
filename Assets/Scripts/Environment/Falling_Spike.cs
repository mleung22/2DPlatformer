using UnityEngine;
using System.Collections;

public class Falling_Spike : MonoBehaviour {

    public int fallSpeed;
    public GameObject spike;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }
    void OnTriggerEnter2D(Collider2D c)
    {

        
        if (c.CompareTag("Player"))
        {
            StartCoroutine(Fall());
            
            
        }

    }

    void Update()
    {
        if (spike.transform.position == player.transform.position)
        {
            Destroy(spike); 
        }
    }

    IEnumerator Fall()
    {
        spike.GetComponent<Rigidbody2D>().isKinematic = false;
        yield return 0;
    }




}
