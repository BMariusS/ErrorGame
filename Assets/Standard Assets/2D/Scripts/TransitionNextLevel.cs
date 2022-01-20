using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionNextLevel : MonoBehaviour {

    private float timer = 1.5f;
    //private bool count = false;

    private void Update() {
        //if(count == true) {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex + 1);
            }
       // }
    }
    //private void OnTriggerEnter2D(Collider2D other) {
    //    if(other.tag == "Player") {
    //        count = true;
    //    }
    //}
}
