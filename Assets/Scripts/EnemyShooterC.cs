using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterC : MonoBehaviour
{

	public GameObject shotPrefab;
	public float fireRate = 0.4f;
	public float nextFire = 0.0f;

	void Update ()
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			GameObject x = Instantiate(shotPrefab);
			Rigidbody2D rbNew = x.GetComponent<Rigidbody2D>();
			Rigidbody2D rbThis = GetComponent<Rigidbody2D>();
			rbNew.velocity = new Vector2(0, -8);
			rbNew.position = rbThis.position;
			x.transform.position = gameObject.transform.position;
		}
	}       
}
