using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MusicControl : MonoBehaviour {
	public AudioSource[] Pistas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void play(int indice){
		if (!Pistas [indice].isPlaying) {
			Pistas [indice].Play ();
		}
	}
	public void stop(int indice){
		Pistas [indice].Stop();
	}

	public void crossfade(int indice,float delay=0){
		for(int i=0;i<Pistas.Length;i++ ){
			AudioSource pista = Pistas[i];
			if(i==indice){
				if (!pista.isPlaying) {
					pista.volume = 0;
					pista.Play ();
					DOTween.To(()=> pista.volume, x=> pista.volume = x, 1, delay);
				} 

			}
			else{
				pista.Stop ();
				//DOTween.To(()=> pista.volume, x=> pista.volume = x, 0, delay);
			}

		}

	}

}
