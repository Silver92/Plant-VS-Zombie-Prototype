using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

    private MusicManager musicManager;
    
	// Use this for initialization
	void Start () {
        musicManager = FindObjectOfType<MusicManager>();
        if(musicManager) {
            float volume = PlayerPrefsManager.GetMasterVolume();
            musicManager.SetVolume(volume);
            Debug.Log("Found that music manager " + musicManager);
            Debug.Log("The master volume is " + volume);
            
        } else {
            Debug.LogWarning("No music manager found in start scene, can't set volume");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
