using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float timer = 1;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {       
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-8, 8), Random.Range(8, 8), transform.position.z);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition, transform.rotation);
                timer = 1;
            }
	}
}
