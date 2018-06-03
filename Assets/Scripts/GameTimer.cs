using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 100; 
    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;
    private GameObject coreGame;

	// Use this for initialization
	void Start ()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        coreGame = GameObject.Find("Core Game");
        FindYouWin();
    }

    private void FindYouWin()
    {
        winLabel = GameObject.Find("You Win!");
        if (!winLabel) { Debug.LogWarning("No win label"); }
        winLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        slider.value = Time.timeSinceLevelLoad/levelSeconds;

        bool timeIsUp = Time.timeSinceLevelLoad >= levelSeconds;
        if ( timeIsUp && !isEndOfLevel) {
            //audioSource.Play();
            winLabel.SetActive(true);
            coreGame.SetActive(false);
            //Invoke("LoadNextLevel", audioSource.clip.length+3);
            isEndOfLevel = true;
            Time.timeScale = 0;
        }
	}
    
    void LoadNextLevel () {
        levelManager.LoadNextLevel();
    }
}
