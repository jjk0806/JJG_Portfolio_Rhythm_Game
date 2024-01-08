using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; set; }
    public AudioSource audioSource { get; set; }
    string music = "Ti";
    void Awake()
    {
        if(instance == null)
            instance = this;
        
    }
    void Start()
    {
        //Invoke("MusicStart", 2f);
    }

    void Update()
    {
        if (audioSource != null)
        {           
            //Debug.Log(musicLength);
        }
    }

    void MusicStart()
    {
        AudioClip clip = Resources.Load<AudioClip>("Music/" + music);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        GameManager.instance.status = GameManager.GameStatus.PLAY;       
    }
}
