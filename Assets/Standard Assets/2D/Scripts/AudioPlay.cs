using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour {

    [SerializeField] private AudioClip sound;

        private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            UnityStandardAssets._2D.PlatformerCharacter2D player = other.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
            if(player.DeathsNumber == 0) {
                GetComponent<AudioSource>().PlayOneShot(sound);
                player.DeathsNumber++;
            }
        }
    }

}
