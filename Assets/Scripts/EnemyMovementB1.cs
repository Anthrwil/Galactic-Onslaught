using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovementB1 : MonoBehaviour
{

    public Transform Player;
    int MoveSpeed = 3;
    int MaxDist = 25;
    int MinDist = 0;
    Quaternion baseRotation;
    int health = 80;
    public int enemyScore = 20;

    void Start()
    {
        baseRotation = Quaternion.Euler(180f, 0f, 0f);
        Player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {


        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Call any function to Shoot here or at something
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            transform.rotation = baseRotation;
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
            Player.gameObject.GetComponent<PlayerController>().count += enemyScore;
            Player.gameObject.GetComponent<PlayerController>().SetCountText();
            gameObject.SetActive(false);

        }
    }
}
