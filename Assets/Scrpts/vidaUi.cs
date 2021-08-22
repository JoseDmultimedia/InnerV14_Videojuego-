using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaUi : MonoBehaviour {

    // Use this for initialization
    public static int vida;
    Text vidaui;
    void Start () {
        vidaui = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        vidaui.text = "Estado Mental Al:" + vida + "%";
	}
}
