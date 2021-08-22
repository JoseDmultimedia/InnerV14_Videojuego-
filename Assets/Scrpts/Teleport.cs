using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject EndPoint;
    public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Travel());
        }
    }

    IEnumerator Travel()
    {
        yield return new WaitForSeconds(0.05f);
        Player.transform.position = new Vector2(EndPoint.transform.position.x, EndPoint.transform.position.y);

    }
}
