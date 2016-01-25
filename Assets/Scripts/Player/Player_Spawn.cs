using UnityEngine;
using System.Collections;

public class Player_Spawn : MonoBehaviour {

    public GameObject spawn;
    public GameObject player;
	// Use this for initialization
	void Start () {
        Instantiate(player, spawn.transform.position, Quaternion.identity);
	}
	

}
