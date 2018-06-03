using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

	private void Start()
	{
        if(autoLoadNextLevelAfter <= 0){
            Debug.Log("Level auto boad disabled");
        } else {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
        
	}
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
        Time.timeScale = 1;
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
    
    public void LoadNextLevel(){
        //Application.LoadLevel(Application.loadedLevel + 1);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

}
