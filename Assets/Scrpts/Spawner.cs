using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject enemy;
    public Transform[] spawSpots;
    private float timeBtSpawn;
    public float startTimeBtSpawns;

	// Use this for initialization
	void Start () {
        timeBtSpawn = startTimeBtSpawns;
	}
	
	// Update is called once per frame
	void Update () {

        

        if (timeBtSpawn <= 0)
        {
            int randPos = Random.Range(0, spawSpots.Length);
            Instantiate(enemy, spawSpots[randPos].position, Quaternion.identity);
            timeBtSpawn = startTimeBtSpawns;
        }
        else
        {
            timeBtSpawn -= Time.deltaTime;
        }
		
	}
}
