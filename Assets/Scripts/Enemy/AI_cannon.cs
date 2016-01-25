using UnityEngine;
using System.Collections;

public class AI_cannon : MonoBehaviour {

    public int currentHealth;
    public int maxHealth;

    public float distance;
    public float shootInterval;
    public float bulletSpeed;
    public float bulletTimer;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPoint;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        RangeCheck();
	}

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        
    }

    public void Attack()
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            GameObject bulletClone;
            bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            bulletTimer = 0;
        }
    }
}
