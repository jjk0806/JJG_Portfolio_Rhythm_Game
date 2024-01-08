using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public ObjectPooler objectPooler { get; set; }

    public float songTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = this.GetComponent<ObjectPooler>();        
    }

    void Update()
    {
        if(AudioManager.instance.audioSource != null)
            songTime = AudioManager.instance.audioSource.clip.length;
    }
}
