using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillzoneBoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "Player") {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}
