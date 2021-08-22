using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    public GameObject GameOverText;
    public static GameObject GameOverStatic;

    // Use this for initialization
    void Start()
    {

        Win.GameOverStatic = GameOverText;
        Win.GameOverStatic.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void show()
    {
        Win.GameOverStatic.gameObject.SetActive(true);
    }
}
