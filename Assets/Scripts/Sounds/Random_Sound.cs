using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Sound : MonoBehaviour
{

    AudioSource audioSource;
    public List<AudioClip> sounds;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine (RandomSounds());
    }

    // Update is called once per frame
  IEnumerator RandomSounds ()
  {
      while (true)
      {
        audioSource.PlayOneShot(sounds[Random.Range(0,sounds.Count)]);
        yield return new WaitForSeconds (Random.Range(8f,10f));
      }
  }
}
