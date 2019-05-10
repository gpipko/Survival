using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectsWithTag("FinalScore")[0].GetComponent<Text>().text = String.Concat("FINAL SCORE: ", PlayerPrefs.GetString("Score", "ERROR"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
