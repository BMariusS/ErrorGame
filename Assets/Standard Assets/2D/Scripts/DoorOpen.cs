using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    [SerializeField]
    private Sprite spriteImage;
    [SerializeField]
    private AudioClip soundDoorClosed;
    [SerializeField]
    private AudioClip soundDoorOpen;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            GameObject findPlayer = GameObject.Find("CharacterRobotBoy");
            CollectObject key = findPlayer.GetComponent<CollectObject>();
            UnityStandardAssets._2D.PlatformerCharacter2D player = findPlayer.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
            if (!key.IsCollected && player.M_IsAlive) {
                GetComponent<AudioSource>().PlayOneShot(soundDoorClosed);
            }
            if (key.IsCollected && player.M_IsAlive) {
                gameObject.GetComponent<Collider2D>().enabled = false;
                key.IsCollected = false;
                GetComponent<AudioSource>().PlayOneShot(soundDoorOpen);
                GetComponent<SpriteRenderer>().sprite = spriteImage;

            }
        }
    }
}
