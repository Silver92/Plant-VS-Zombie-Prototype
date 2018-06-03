using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);
        
    }
    
    void OnEnable( )
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
        Debug.Log("Playing clip: " + thisLevelMusic);
                
        if(thisLevelMusic) {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
}