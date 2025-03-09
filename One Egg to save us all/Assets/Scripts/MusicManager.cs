using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource musicPlayer;
    public AudioClip track1;
    public AudioClip track2;
    private float timePlayed;
    private bool track; // false = 1, true = 2
    void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("music");
        track = true;
        if (players.Length > 1)
        {
            Destroy(gameObject);
        }
        musicPlayer = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        timePlayed += Time.deltaTime;
        Debug.Log(track2.length);
        if (track)
        {
            if (timePlayed >= track1.length)
            {
                timePlayed = 0.7f;
                musicPlayer.clip = track2;
                musicPlayer.Play();
                track = false;
            }
        }
        else
        {
            if (timePlayed >= track2.length)
            {
                timePlayed = 1f;
                musicPlayer.clip = track1;
                musicPlayer.Play();
                track = true;
            }
        }
    }
}
