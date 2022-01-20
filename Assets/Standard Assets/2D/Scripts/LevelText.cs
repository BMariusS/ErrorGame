using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

    // Use this for initialization
    Text instruction;
    private int sceneIndex;

    void Start() {
        sceneIndex = SceneManager.GetSceneAt(0).buildIndex;
        instruction = gameObject.GetComponent<Text>();
        instruction.text = "    Level " + sceneIndex/2;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
