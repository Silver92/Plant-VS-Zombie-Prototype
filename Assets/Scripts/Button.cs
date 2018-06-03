using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject DefenderPrefab;

    private Button[] buttonarray;
    public static GameObject selectedDefender;
    private Text costText;

	// Use this for initialization
	void Start () {
        buttonarray = FindObjectsOfType<Button>();

        costText = GetComponentInChildren<Text>();
        if (!costText) { Debug.LogWarning(name + " has no text"); }

        costText.text = DefenderPrefab.GetComponent<Defenders>().starCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        foreach (Button thisButton in buttonarray) {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = DefenderPrefab;
        
    }
}
