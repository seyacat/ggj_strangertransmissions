using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCollider : MonoBehaviour {

    internal List<Transform> close_enemies = new List<Transform>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider inc_object)
    {
        if (inc_object.gameObject.name == "EnemyCollider")
            if (!close_enemies.Contains(inc_object.transform))
                close_enemies.Add(inc_object.transform);
        //if (inc_object.gameObject.name == "EnemyCollider")
        //{

        //    transform.parent.GetComponent<DefensePuzzle>().close = false;
        //    transform.parent.Find("Close").gameObject.SetActive(true);
        //}
        if (close_enemies.Count > 0)
        {
            transform.parent.GetComponent<DefensePuzzle>().close = true;
            //transform.parent.Find("Close").gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider inc_object)
    {
        if (inc_object.gameObject.name == "EnemyCollider")
            if (close_enemies.Contains(inc_object.transform))
                close_enemies.Remove(inc_object.transform);
        //if (inc_object.gameObject.name == "EnemyCollider")
        //{

        //    transform.parent.GetComponent<DefensePuzzle>().close = false;
        //    transform.parent.Find("Close").gameObject.SetActive(true);
        //}
        if (close_enemies.Count == 0)
        {
            transform.parent.GetComponent<DefensePuzzle>().close = false;
            //transform.parent.Find("Close").gameObject.SetActive(false);
        }
    }
}
