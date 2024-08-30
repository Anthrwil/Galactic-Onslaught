using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject shotPrefab;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    public float speed;
    private Rigidbody2D rb2d;
    public int Damage;
    public AudioClip ShootSound;
    private AudioSource source;
    public float vol;

    void Start ()
    {
        source = GetComponent<AudioSource>();
    }

    void Update ()
    {

        Damage = GetComponent<PlayerController>().Damage;
        Vector3 mousePositionVector3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        mousePositionVector3 = Camera.main.ScreenToWorldPoint(mousePositionVector3);

        Vector3 targetdir = mousePositionVector3 - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetdir);

        if (Input.GetMouseButton(0) && Time.time > nextFire || (Input.GetKey("space")) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject newBullet = Instantiate(shotPrefab, transform.position, transform.rotation) as GameObject;
            Rigidbody2D rigid = newBullet.GetComponent<Rigidbody2D>();
            rigid.velocity = transform.up * 10;
            newBullet.GetComponent<bulletDamage>().Damage = GetComponent<PlayerController>().Damage = Damage;
            source.PlayOneShot(ShootSound, vol);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            fireRate = 0.1f;
            Invoke("ResetFireRate", 4);
        }
    }

    void ResetFireRate()
    {
        fireRate = 0.2f;
    }
}
