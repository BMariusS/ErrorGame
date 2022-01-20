using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayEndLevel : MonoBehaviour {

    [SerializeField] private AudioClip sound;
    private bool onlyOnce = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && onlyOnce == true)
        {
            onlyOnce = false;
            GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }
}
