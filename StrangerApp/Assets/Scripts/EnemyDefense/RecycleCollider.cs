using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleCollider : MonoBehaviour {
    
    void OnTriggerEnter(Collider inc_object)
    {
        if (inc_object.gameObject.name == "EnemyCollider")
        {
            inc_object.transform.parent.GetComponent<EnemyController>().active = false;
            inc_object.transform.parent.SetAsLastSibling();
        }
    }
}
