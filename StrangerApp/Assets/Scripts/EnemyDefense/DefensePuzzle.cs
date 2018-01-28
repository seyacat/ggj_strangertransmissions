using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensePuzzle : MonoBehaviour
{

    public bool alive = true;
    public bool close = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other_unit)
    {
        if (other_unit.gameObject.name == "EnemyCollider")
        {
            //string debug = other_unit.transform.parent.name;
            //string debug2 = this.transform.parent.name;
            //var other_guc = other_unit.transform.parent.GetComponent<Generic_Unit_Controller>();
            //if (parent_guc != null)
            //    if (other_guc == parent_guc)
            //        return;
            //if (other_guc != null)
            //    other_guc.unit_behaviour.HeardNoise(parent_sound);
            alive = false;

            //transform.Find("Box").gameObject.SetActive(true);
        }
    }
}
