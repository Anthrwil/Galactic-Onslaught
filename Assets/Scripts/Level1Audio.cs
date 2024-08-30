using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Audio : MonoBehaviour
{

    public AudioClip Level1Music;
    private AudioSource source;
    public float vol;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        source.PlayOneShot(Level1Music, vol);
    }
}
