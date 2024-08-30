using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovementC : MonoBehaviour
{

	public Transform Player;
	int MoveSpeed = 2;
	int MaxDist = 25;
	int MinDist = 0;
	Quaternion baseRotation; 
	int health = 50;
    public int enemyScore = 30;
    public float PowerUp;
    public bool AtkSpeed;
    public bool AtkDmg;
    public bool HealthUp;
    public bool OneUP;
    public bool MvSpd;
    public GameObject AttkSpeed;
    public GameObject AttkDmg;
    public GameObject HealthUP;
    public GameObject OneUp;
    public GameObject MVSpd;
    public bool Blank1;
    public bool Blank2;
    public bool Blank3;
    public bool Blank4;
    public bool Blank5;
    public bool Blank6;

    void Start()
	{
		baseRotation = Quaternion.Euler (180f, 0f, 0f);
        Player = GameObject.FindWithTag("Player").transform;
        PowerUp = Random.Range(1, 11);
    }

	void Update()
	{
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - MoveSpeed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (PowerUp == 1)
        {
            AtkSpeed = true;
        }
        if (PowerUp == 2)
        {
            AtkDmg = true;
        }
        if (PowerUp == 3)
        {
            HealthUp = true;
        }
        if (PowerUp == 4)
        {
            OneUP = true;
        }
        if (PowerUp == 5)
        {
            Blank1 = true;
        }
        if (PowerUp == 6)
        {
            Blank2 = true;
        }
        if (PowerUp == 5)
        {
            Blank3 = true;
        }
        if (PowerUp == 6)
        {
            Blank4 = true;
        }
        if (PowerUp == 5)
        {
            Blank5 = true;
        }
        if (PowerUp == 6)
        {
            Blank6 = true;
        }
        if (PowerUp == 7)
        {
            MvSpd = true;
        }
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Bullet")) 
		{
			other.gameObject.SetActive (false);
            health = health - other.GetComponent<bulletDamage>().Damage;
            checkdeath();
		}
	}

	void checkdeath()
	{
        if (health <= 0 && AtkSpeed == true)
        {
            Player.gameObject.GetComponent<PlayerController>().count += enemyScore;
            Player.gameObject.GetComponent<PlayerController>().SetCountText();
            Instantiate(AttkSpeed, transform.position, transform.rotation);
            gameObject.SetActive(false);

        }
        if (health <= 0 && AtkDmg == true)
        {
            Player.gameObject.GetComponent<PlayerController>().count += enemyScore;
            Player.gameObject.GetComponent<PlayerController>().SetCountText();
            Instantiate(AttkDmg, transform.position, transform.rotation);
            gameObject.SetActive(false);

        }
        if (health <= 0 && HealthUp == true)
        {
            Player.gameObject.GetComponent<PlayerController>().count += enemyScore;
            Player.gameObject.GetComponent<PlayerController>().SetCountText();
            Instantiate(HealthUP, transform.position, transform.rotation);
            gameObject.SetActive(false);

        }
        if (health <= 0 && OneUP == true)
        {
            Player.gameObject.GetComponent<PlayerController>().count += enemyScore;
            Player.gameObject.GetComponent<PlayerController>().SetCountText();
            Instantiate(OneUp, transform.position, transform.rotation);
            gameObject.SetActive(false);

        }
        if (health <= 0 && MvSpd == true)
        {
            Player.gameObject.GetComponent<PlayerController>().count += enemyScore;
            Player.gameObject.GetComponent<PlayerController>().SetCountText();
            Instantiate(MVSpd, transform.position, transform.rotation);
            gameObject.SetActive(false);

        }
        if (health <= 0 && Blank1 == true)
        {
            Player.gameObject.GetComponent<PlayerController>().count += enemyScore;
            Player.gameObject.GetComponent<PlayerController>().SetCountText();
            gameObject.SetActive(false);

        }
        if (health <= 0 && Blank2 == true)
        {
            Player.gameObject.GetComponent<PlayerController>().count += enemyScore;
            Player.gameObject.GetComponent<PlayerController>().SetCountText();
            gameObject.SetActive(false);

        }
        if (health <= 0 && Blank3 == true)
        {
            Player.gameObject.GetComponent<PlayerController>().count += enemyScore;
            Player.gameObject.GetComponent<PlayerController>().SetCountText();
            gameObject.SetActive(false);

        }
        if (health <= 0 && Blank4 == true)
        {
            Player.gameObject.GetComponent<PlayerController>().count += enemyScore;
            Player.gameObject.GetComponent<PlayerController>().SetCountText();
            gameObject.SetActive(false);

        }
        if (health <= 0 && Blank5 == true)
        {
            Player.gameObject.GetComponent<PlayerController>().count += enemyScore;
            Player.gameObject.GetComponent<PlayerController>().SetCountText();
            gameObject.SetActive(false);

        }
        if (health <= 0 && Blank6 == true)
        {
            Player.gameObject.GetComponent<PlayerController>().count += enemyScore;
            Player.gameObject.GetComponent<PlayerController>().SetCountText();
            gameObject.SetActive(false);

        }
    }
}	