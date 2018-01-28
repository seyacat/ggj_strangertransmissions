using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseController : MonoBehaviour
{

    private Ray ray;
    private RaycastHit[] ray_hits = new RaycastHit[1];
    private List<Transform> tentacles = new List<Transform>();
    private bool cast_started = false;
    private float cast_duration = 0;
    public Transform main_camera = null;

    float max_duration = 25f;

    // Use this for initialization

    void FixedUpdate()
    {
        if (cast_started)
        {
            cast_duration = cast_duration + 1f;
            float temp_percentage = cast_duration / max_duration;
            foreach (var tentacle in tentacles)
            {
                tentacle.Find("TentacleCanvas").Find("Radial").GetComponent<Image>().fillAmount = temp_percentage;
                if (cast_duration > max_duration)
                {
                    tentacle.parent.GetComponent<EnemyController>().defeated = true;
                    tentacle.Find("TentacleCanvas").Find("Radial").GetComponent<Image>().fillAmount = 0;
                    tentacle.parent.Find("SoundRadial").GetComponent<AudioSource>().Stop();
                    tentacle.parent.Find("HitSound").GetComponent<AudioSource>().Play();
                }
            }
            if (cast_duration > max_duration)
            {
                cast_started = false;
            }
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            if (!cast_started)
            {
                tentacles.Clear();
                ray = main_camera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

                ray_hits = Physics.RaycastAll(ray);
                foreach (var hit in ray_hits)
                {
                    if (hit.transform.name == "EnemyCollider")
                        if (!hit.transform.parent.GetComponent<EnemyController>().defeated)
                        {
                            tentacles.Add(hit.transform);
                            hit.transform.parent.Find("SoundRadial").GetComponent<AudioSource>().Play();
                            hit.transform.parent.Find("HitSound").GetComponent<AudioSource>().Stop();
                        }
                }
                cast_duration = 0;
                cast_started = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {

            if (cast_duration < max_duration)
            {
                foreach (var tentacle in tentacles)
                {
                    tentacle.Find("TentacleCanvas").Find("Radial").GetComponent<Image>().fillAmount = 0;
                    tentacle.parent.Find("SoundRadial").GetComponent<AudioSource>().Stop();
                }
            }
            cast_started = false;
            tentacles.Clear();
        }

    }
}
