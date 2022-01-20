using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    // Use this for initialization
    public KeyManager keyManager;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            keyManager = FindObjectOfType<KeyManager>();
            keyManager.currentKey = gameObject;
            
        }

    }
}
