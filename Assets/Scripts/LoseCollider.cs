using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private GameObject loseLabel;
    private GameObject coreGame;

	// Use this for initialization
	void Start () {
        LosePanel();
        coreGame = GameObject.Find("Core Game");
	}
    
    private void LosePanel() {
        loseLabel = GameObject.Find("You Lost");
        if (!loseLabel) { Debug.LogWarning("No lost label"); }
        loseLabel.SetActive(false);
    
    }
	

    private void OnTriggerEnter2D(Collider2D collision)
    {
        loseLabel.SetActive(true);
        coreGame.SetActive(false);
        Time.timeScale = 0;
    }
}
