using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {


    public string mainMenu;
    public bool isPaused;
    public GameObject pauseMenuCanvas;
    [SerializeField]
    //public string sceneIndex;
    public int sceneIndex;
    private GameObject findMusic;
    private AudioSource musicSource;

    private void Start() {
        findMusic = GameObject.Find("Audio Source");
        musicSource = findMusic.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if(isPaused) {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            musicSource.Pause();
            
        }
        else {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
            musicSource.UnPause();

        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
        }

    }

    public void Resume() {
        isPaused = false;
    }

    public void Menu() {
        SceneManager.LoadScene(mainMenu);
        sceneIndex = SceneManager.GetSceneAt(0).buildIndex - 1;
        PlayerPrefs.SetInt("SceneToLoad", sceneIndex);
    }

    public void Quit() {
        sceneIndex = SceneManager.GetSceneAt(0).buildIndex - 1;
        PlayerPrefs.SetInt("SceneToLoad", sceneIndex);
        Application.Quit();

    }
}
