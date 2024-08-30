using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject BossMob;

	// Use this for initialization
	void Start ()
    {
        EndGame();
	}
	
	// Update is called once per frame
	void Update ()
    {
        EndGame();
	}

    void EndGame()
    {
        if (GetComponent<PlayerController>().count >= 250)
        {
            BossMob.SetActive(true);
        }
    }
}
