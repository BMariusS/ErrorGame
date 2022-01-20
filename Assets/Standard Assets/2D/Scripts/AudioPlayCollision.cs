using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayCollision : MonoBehaviour {

    [SerializeField]
    private AudioClip sound;
    private bool touch = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            UnityStandardAssets._2D.PlatformerCharacter2D player = other.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
            Debug.Log(player.DeathsNumber);
            
            if(player.DeathsNumber == 0)
            {
                if (GetComponent<AudioSource>())
                {
                    GetComponent<AudioSource>().PlayOneShot(sound);
                }
                player.DeathsNumber++;
            }

            //if(gameObject.name == "Robot" && touch == false) {
            //    touch = true;
            //    Debug.Log("test");
            //    Debug.Log(touch);
            //    GetComponent<AudioSource>().PlayOneShot(sound);
            //}
            
            //Debug.Log(player.DeathsNumber);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            UnityStandardAssets._2D.PlatformerCharacter2D player = other.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
            Debug.Log(player.DeathsNumber);
            if(player.DeathsNumber == 0) {
                GetComponent<AudioSource>().PlayOneShot(sound);
                player.DeathsNumber++;
            }
            Debug.Log(player.DeathsNumber);
        }
    }

    //public bool Touch {
    //    get {
    //        return touch;
    //    }
    //    set {
    //        touch = value;
    //    }
    //}

}
