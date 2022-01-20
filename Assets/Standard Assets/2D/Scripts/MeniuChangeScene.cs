using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeniuChangeScene : MonoBehaviour {

    public void MeniuChangeToScene(int sceneToChange)
    {
        SceneManager.LoadScene(sceneToChange);
    }
}
