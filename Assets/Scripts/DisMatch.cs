using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisMatch : MonoBehaviour
{
    public AudioSource audioSource;
    public static DisMatch instance;
    public AudioClip clip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Bbik()
    {
        audioSource.volume = 0.1f;
        audioSource.PlayOneShot(clip);
        
    }

}
