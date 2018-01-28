using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class once : MonoBehaviour {

	public MusicControl fx;

	public GameObject cam;


	public GameObject[] spots;
	public CanvasGroup canvasTorre;
	public CanvasGroup canvasRadio;
	GameObject tg;
	Vector3 startpos;
	//var startrot;
	float dt;
	float ds;
	float speed = 1.0F;
	int spotnum = 3;
	bool correr = false;
	// Use this for initialization
	void Start () {		
		tg = spots [3];
		startpos = transform.position;
		dt = 0;
		ds = Vector3.Distance (transform.position, tg.transform.position);

		DOTween.To(()=> canvasTorre.alpha, x=> canvasTorre.alpha = x, 0, 0);
		DOTween.To(()=> canvasRadio.alpha, x=> canvasRadio.alpha = x, 0, 0);
		}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit))
				//Debug.Log (hit);
			if (hit.collider != null){
				//hit.collider.enabled = false;
				if(hit.transform.name=="mesa1"){
					spotnum = 0;
					tg = spots [spotnum];
					startpos = transform.position;
					dt = 0;
					ds = Vector3.Distance (transform.position, tg.transform.position);
					cam.GetComponent<Animator> ().CrossFade ("spot1", 1);
					DOTween.To(()=> canvasTorre.alpha, x=> canvasTorre.alpha = x, 1, 1);
					DOTween.To(()=> canvasRadio.alpha, x=> canvasRadio.alpha = x, 0, 1);
					//startrot = transform.rotation;
				}
				if(hit.transform.name=="mesa2"){
					spotnum = 1;
					tg = spots [spotnum];
					startpos = transform.position;
					dt = 0;
					ds = Vector3.Distance (transform.position, tg.transform.position);
					cam.GetComponent<Animator> ().CrossFade ("spot2", 1);
					DOTween.To(()=> canvasTorre.alpha, x=> canvasTorre.alpha = x, 0, 1);
					DOTween.To(()=> canvasRadio.alpha, x=> canvasRadio.alpha = x, 1, 1);
					//startrot = transform.rotation;
				}
				if(hit.transform.name=="mesa3"){
					spotnum = 2;
					tg = spots [spotnum];
					startpos = transform.position;
					dt = 0;
					ds = Vector3.Distance (transform.position, tg.transform.position);
					cam.GetComponent<Animator> ().CrossFade ("spot3", 1);
					DOTween.To(()=> canvasTorre.alpha, x=> canvasTorre.alpha = x, 0, 1);
					DOTween.To(()=> canvasRadio.alpha, x=> canvasRadio.alpha = x, 0, 1);
					//startrot = transform.rotation;
				}
				if(hit.transform.name=="mesa4"){
					spotnum = 3;
					tg = spots [spotnum];
					startpos = transform.position;
					dt = 0;
					ds = Vector3.Distance (transform.position, tg.transform.position);
					cam.GetComponent<Animator> ().CrossFade ("spot1", 1);
					DOTween.To(()=> canvasTorre.alpha, x=> canvasTorre.alpha = x, 0, 1);
					DOTween.To(()=> canvasRadio.alpha, x=> canvasRadio.alpha = x, 0, 1);
					//startrot = transform.rotation;
				}
			}



		}
		if (correr) {
			fx.play (5);//PASOS
		} else {
			fx.stop (5);
		}
		if (dt < 1) {
			if (!correr) {
				correr = true;
				GetComponentInChildren<Animator> ().CrossFade ("correr", 0.1f);
				Vector3 dirvec = tg.transform.position - transform.position;
				if (Vector3.Dot (dirvec, Vector3.right) > 0) {
					transform.eulerAngles = new Vector3 (0, 90, 0);
					//GetComponentInChildren<Animator> ().CrossFade ("correr", 1);

				} else {				
					transform.eulerAngles = new Vector3 (0, -90, 0);
					//GetComponentInChildren<Animator> ().CrossFade ("correr", 1);
				}

			}
			transform.position = Vector3.Lerp (startpos, tg.transform.position, dt);
			dt += 0.2f / ds;
		} else {
			if (correr) {
				correr = false;
				if (spotnum == 0) {
					transform.eulerAngles = new Vector3 (0, -90, 0);
					GetComponentInChildren<Animator> ().CrossFade ("maquina", 0.1f);
					fx.play (1);
				}
				if (spotnum == 1) {
					transform.eulerAngles = new Vector3 (0, 0, 0);
					GetComponentInChildren<Animator> ().CrossFade ("maquina", 0.1f);
				}
				if (spotnum == 2) {
					transform.eulerAngles = new Vector3 (0, 90, 0);;
					GetComponentInChildren<Animator> ().CrossFade ("pensando", 0.1f);
				}
				if (spotnum == 3) {
					transform.eulerAngles = new Vector3 (0, 180, 0);;
					GetComponentInChildren<Animator> ().CrossFade ("idle", 0.1f);
				}
				}


			}
		//Debug.Log (target);
		//MoveObject.use.Translation (this.transform, target.transform.position, 1, MoveObject.MoveType.Time);
	}



}
