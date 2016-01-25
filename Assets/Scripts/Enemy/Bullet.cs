using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c)
    {
        if(c.isTrigger != true)
        {
            if (c.CompareTag("Player"))
            {
                c.GetComponent<Player>().knockBack(0.5f, -50, transform.position);
                StartCoroutine(c.GetComponent<Player>().damage(1));
            }

            Destroy(gameObject);


        }

        if (c.CompareTag("BulletTarget"))
        {
            DestroyObject(gameObject);
        }
    }

 
}
