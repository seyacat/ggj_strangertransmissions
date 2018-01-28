using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    internal bool defeated = false;
    public bool active = false;

    public float speed = 0.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (active)
            if (defeated)
            {
                transform.position = new Vector3(transform.position.x + (speed * 2f) , transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
                //TODO:
                //If reaches start position = then deactivate
            }
	}
}
