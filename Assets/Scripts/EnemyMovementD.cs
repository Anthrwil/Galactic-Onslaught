using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovementD : MonoBehaviour
{
    public Transform Player;
    int health = 70;
    public int enemyScore = 40;
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

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        PowerUp = Random.Range(1, 5);
    }

    void Update()
    {
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
            MvSpd = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            health = health - other.GetComponent<bulletDamage>().Damage;
            checkdeath();
        }
    }

    void checkdeath()
    {
        if (health <= 0)
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
        }
    }
}
