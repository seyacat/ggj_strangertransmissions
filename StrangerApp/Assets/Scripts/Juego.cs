using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Juego : MonoBehaviour {
	
	public AssaultController assault;
	public DefensePuzzle defence;
	public GameObject CanvasAlert;

	public MusicControl musica;
	public MusicControl fx;
	public TowerGrid puzzle;
	public Animator animAntena;
	bool antenaAnimFlag = false;

	public GameObject[] Paneles; 
	string estadoJuego="none";
	string estadoJuegoOld="";
	string estadoPaneles = "inicio";
	string estadoPanelesOld = "";

	public int default_time = 5;
	public int tiempo;

	public GameObject txtTiempo;



	// Use this for initialization
	void Start () {		
		StartCoroutine (Tic ());
		assault.enabled = false; //TENTACULOS APAGADOS
	}

	IEnumerator Tic(){
		while (true) {
			if (estadoJuego == "juego") {
				//tiempo--;
				txtTiempo.GetComponentInChildren<Text> ().text = "" + tiempo;
				if (tiempo <= 0) {
					estadoJuego = "fin";
					estadoPaneles = "fin";
				}
			}
			yield return new WaitForSeconds (1);
		}
		yield return true;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("escape")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
			

		if (estadoJuego != estadoJuegoOld) {
			estadoJuegoOld = estadoJuego;
			if (estadoJuego == "inicio") {
				estadoJuego = "juego";
				tiempo = default_time;
				assault.enabled = true; //TENTACULOS Encendidos

			}
		}
		if (estadoPaneles != estadoPanelesOld) {
			estadoPanelesOld = estadoPaneles;
			if (estadoPaneles == "inicio") {
				musica.crossfade (0);//beginning song

				}
			if (estadoPaneles == "win") {
				musica.crossfade (1);
			}
			if (estadoPaneles == "hud") {
				musica.crossfade (2,5);//enemies song
				fx.play (3);//mike
			}
			if (estadoPaneles == "fin") {
				musica.crossfade (3);
			}
			foreach(GameObject panel in Paneles){
				if (panel.name == estadoPaneles) {
					panel.SetActive (true);
				} else {
					panel.SetActive (false);
				}
			}
		}

		if(puzzle.solved==true){			
			if (!antenaAnimFlag) {
				antenaAnimFlag = true;
				animAntena.CrossFade ("on", 1);
			}
		}



		if (estadoJuego == "juego") {
			if (defence.close) {
				CanvasAlert.SetActive (true);
			} else {
				CanvasAlert.SetActive (false);
			}
			if (defence.alive == false) {
				finMalo ();
			}
		}


	}

	void finMalo(){
		estadoJuego = "fin";
		estadoPaneles = "fin";
		CanvasAlert.SetActive (false);
		}
	void finBueno(){
		estadoJuego = "win";
		estadoPaneles = "win";
		CanvasAlert.SetActive (false);

		}

	public void testTransmission(){
		if (puzzle.solved) {
			fx.play (4);
			float dummy = 0;
			DOTween.To(()=> dummy, x=> dummy = x, 1, 3).OnComplete(finBueno);
		} else {
			fx.play (2);
		}
			
		}

	public void setEstadoPaneles(string str){
		if (str == "inicio" && (estadoPaneles=="fin"||estadoPaneles=="win")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		estadoPaneles = str;

	}
	public void setEstadoJuego(string str){
		estadoJuego = str;
	}

	public void quit(){
		Application.Quit();

	}
}
