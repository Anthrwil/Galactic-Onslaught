﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootable : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }	
}
