using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour {


    [SerializeField] private bool isCollected;
    [SerializeField]
    private AudioClip soundCollectKey;
    // Use this for initialization
    void Start () {
        isCollected = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("PickUp")) {
            isCollected = true;
            other.gameObject.SetActive(false);
            GetComponent<AudioSource>().PlayOneShot(soundCollectKey);
        }
    }

    public bool IsCollected {
        get {
            return isCollected;
        }

        set {
            isCollected = value;
        }
    }
}