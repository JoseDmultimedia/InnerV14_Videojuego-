using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    // Use this for initialization
    public static int scoreValu = 0;
    Text scores;
	void Start () {
        scores = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scores.text = "Eliminados: " + scoreValu;
	}
}
