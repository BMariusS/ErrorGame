using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    // Use this for initialization
    public string firstLevel;
    private PauseMenu continueGame;
    public string mainMenu;
    private GameObject findContinue;
    private Button continueNotClickable; 


    private void Start() {
        Debug.Log(PlayerPrefs.GetInt("SceneToLoad"));
        if (PlayerPrefs.GetInt("SceneToLoad") == 0)
        {
            if (GameObject.Find("Continue"))
            {
                findContinue = GameObject.Find("Continue");
                continueNotClickable = findContinue.GetComponent<Button>();
                continueNotClickable.interactable = false;
            }
        }
    }

    private void Update() {
    }

    public void ContinueGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneToLoad"));
    }

    public void Menu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(firstLevel);
    }

    public void QuitGame() {
        Application.Quit();
    }
    public void QuitToMainMenu()
    {
        PlayerPrefs.SetInt("SceneToLoad", 0);
        SceneManager.LoadScene(mainMenu);
    }
    public void QuitGameEnd()
    {
        Application.Quit();
    }
    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
