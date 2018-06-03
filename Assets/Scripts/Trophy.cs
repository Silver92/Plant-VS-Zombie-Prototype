using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour {

    private StarDisplay starDisplay;
    
    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }
    
	public void AddStars (int amount) {
        starDisplay.AddStars(amount);
    }
}
