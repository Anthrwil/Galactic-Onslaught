using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text Health;
    public Text Lives;
    public int health = 100;
    public int lives = 3;
    public Text GameOver;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject BossMob;
    public bool scriptActive = true;
    public AudioClip DmgSound;
    private AudioSource source;
    public float vol;
    public AudioClip PowerUp;
    public float vol1;
    public AudioClip PowerDown;
    public float vol2;

    public int Damage = 10;

    private Rigidbody2D rb2d;
    public int count;

    void Start()
    {
        scriptActive = true;
        rb2d = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();

        count = 0;
        winText.text = "";
        SetCountText();
        GameOver.text = "";
        GameFinished();
        Health.text = "Health: " + health;
        Lives.text = "Lives: " + lives;
    }

    void FixedUpdate()
    {
        if (scriptActive)
        {
            Health.text = "Health: " + health;
            Lives.text = "Lives: " + lives;
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.AddForce(movement * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (scriptActive)
        {
            if (other.gameObject.CompareTag("Enemy Bullet A"))
            {
                source.PlayOneShot(DmgSound, vol);
                other.gameObject.SetActive(false);
                health = health - 10;               
                LifeLine();
            }
            if (other.gameObject.CompareTag("Enemy A"))
            {
                source.PlayOneShot(DmgSound, vol);
                other.gameObject.SetActive(false);
                health = health - 10;              
                LifeLine();
            }
            if (other.gameObject.CompareTag("Enemy Bullet B"))
            {
                source.PlayOneShot(DmgSound, vol);
                other.gameObject.SetActive(false);
                health = health - 20;                
                LifeLine();
            }
            if (other.gameObject.CompareTag("Enemy B"))
            {
                source.PlayOneShot(DmgSound, vol);
                other.gameObject.SetActive(false);
                health = health - 10;               
                LifeLine();
            }
            if (other.gameObject.CompareTag("Enemy Bullet C"))
            {
                source.PlayOneShot(DmgSound, vol);
                other.gameObject.SetActive(false);
                health = health - 30;                
                LifeLine();
            }
            if (other.gameObject.CompareTag("Enemy Bullet B1"))
            {
                source.PlayOneShot(DmgSound, vol);
                other.gameObject.SetActive(false);
                health = health - 40;
                LifeLine();
            }
            if (other.gameObject.CompareTag("Boss"))
            {
                source.PlayOneShot(DmgSound, vol);
                health = health - 40;
                LifeLine();
            }
            if (other.gameObject.CompareTag("Enemy C"))
            {
                source.PlayOneShot(DmgSound, vol);
                other.gameObject.SetActive(false);
                health = health - 10;                
                LifeLine();
            }
            if (other.gameObject.CompareTag("Enemy D"))
            {
                source.PlayOneShot(DmgSound, vol);
                other.gameObject.SetActive(false);
                health = health - 40;                
                LifeLine();
            }
            if (other.gameObject.CompareTag("HealthUp"))
            {
                source.PlayOneShot(PowerUp, vol1);
                other.gameObject.SetActive(false);
                count = count + 10;
                health = health + 25;                
                SetCountText();
            }     
            if (other.gameObject.CompareTag("1UP"))
            {
                source.PlayOneShot(PowerUp, vol1);
                other.gameObject.SetActive(false);
                count = count + 10;
                lives = lives + 1;               
                SetCountText();
            }   
            if (other.gameObject.CompareTag("AtkDmg"))
            {
                source.PlayOneShot(PowerUp, vol1);
                other.gameObject.SetActive(false);
                count = count + 10;
                Damage = Damage * 2;               
                Invoke("HealthReset", 10);
                SetCountText();
            }
            if (other.gameObject.CompareTag("MvSpd"))
            {
                source.PlayOneShot(PowerUp, vol1);
                other.gameObject.SetActive(false);
                speed = 40;               
                Invoke("ResetSpeed", 4);
            }
            else if (other.gameObject.CompareTag("PickUp"))
            {
                source.PlayOneShot(PowerUp, vol1);
                other.gameObject.SetActive(false);
                count = count + 10;              
               SetCountText();
            }
        }
    }

    public void HealthReset()
    {
        source.PlayOneShot(PowerDown, vol2);
        Damage = 10;       
    }

    void ResetSpeed()
    {
        source.PlayOneShot(PowerDown, vol2);
        speed = 25;       
    }
 
    public void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 500)
        {
            WinPanel.SetActive(true);
            scriptActive = false;         
        }
    }   

    void LifeLine()
    {
        if (health <= 0)
        {
            lives = lives - 1;
            health = 100;
            GameFinished();
        }
    }

    void GameFinished()
    {
        if (lives <= -1)
        {
            LosePanel.SetActive(true);
            scriptActive = false;          
        }
    }
}