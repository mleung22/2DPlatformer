using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform[] patrolPoints;
    public int currentPosition;
    public float moveSpeed;

    // Use this for initialization
    void Start () {
        transform.position = patrolPoints[0].position;
        currentPosition = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position == patrolPoints[currentPosition].position)
        {
            currentPosition++;
            
        }

        if (currentPosition >= patrolPoints.Length)
        {
            currentPosition = 0;
        }

        

        transform.position = Vector3.MoveTowards(
            transform.position, patrolPoints[currentPosition].position, moveSpeed * Time.deltaTime);

        if (transform.position.x < patrolPoints[currentPosition].position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        if (transform.position.x > patrolPoints[currentPosition].position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            c.GetComponent<Player>().knockBack(0.1f, -150, transform.position);
            StartCoroutine(c.GetComponent<Player>().damage(1));

        }
    }
}
