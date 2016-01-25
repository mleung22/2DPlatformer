using UnityEngine;
using System.Collections;

public class Player_Camera : MonoBehaviour {

    public float smoothTimeY;
    public float smoothTimeX;

    public bool bounds;

    public GameObject player;

    private Vector2 velocity;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {

        // if player isn't dead the camera will follow
        if (player != null)
        {
            // Sets positions x and y to move camera from current position to player position with smooth time as the speed it moves at
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
            transform.position = new Vector3(posX, posY, transform.position.z);

            // Sets the camera to a fixed position when bounds is checked as true
            if (bounds)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                    Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                    Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
            }
        }
    }

    // Min possible x and y coordinate for camera position
    public void SetMinCameraPosition()
    {
        minCameraPos = gameObject.transform.position;
    }

    // Max possible x and y coordinate for camera position
    public void SetMaxCameraPosition()
    {
        maxCameraPos = gameObject.transform.position;
    }
}
