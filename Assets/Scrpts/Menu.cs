using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject Panel;


	// Use this for initialization
	void Start () {
        Panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void abrirPanelOpciones()
    {
        Panel.SetActive(true);
    }
    public void cerrarPanel()
    {
        Panel.SetActive(false);
    }
}
