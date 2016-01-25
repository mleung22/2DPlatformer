using UnityEngine;
using System.Collections;

public class Attack_Cone : MonoBehaviour {

    public AI_cannon cannon;

    void Start()
    {
        cannon = gameObject.GetComponentInParent<AI_cannon>();
    }

    void Update()
    {
        cannon.Attack();
    }
	
}
