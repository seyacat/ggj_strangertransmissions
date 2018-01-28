using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultController : MonoBehaviour {

    private float next_increment = 10f;
    private float start_time = 0f;
    private bool assault_start = false;
    void OnEnable()
    {
        start_time = Time.time;
        assault_start = true;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (assault_start)
            if ((Time.time - start_time) > next_increment)
                ActivateFirstAvailableEnemy(); //.GetComponent<EnemyController>().active	
    }

    void ActivateFirstAvailableEnemy()
    {
        foreach (Transform child in transform)
        {
            if (!child.GetComponent<EnemyController>().active)
            {
                child.GetComponent<EnemyController>().active = true;
                break;
            }
        }
        if ((Time.time - start_time) < 40f)
        {
            next_increment = next_increment + 10f;
        }
        else
        {
            if ((Time.time - start_time) < 120f)
                next_increment = next_increment + 5f;
            else
                next_increment = next_increment + 2.5f;
        }
    }
}
