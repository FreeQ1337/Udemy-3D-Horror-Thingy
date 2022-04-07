using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_PlayAudio : MonoBehaviour
{
    AudioSource audioSource;
    private bool HasPlayed = false;
    public AudioClip sound;
    [SerializeField] float WaitBeforeDestroy;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(!HasPlayed && other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(sound,0.8f);
            HasPlayed = true;
            Destroy(gameObject, WaitBeforeDestroy);
        }
    }
}
