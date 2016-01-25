using UnityEngine;
using System.Collections;

public class Platform_Vertical_Movement : MonoBehaviour {

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


    
    }
}
