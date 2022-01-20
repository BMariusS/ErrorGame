using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionRestarter : MonoBehaviour {
    private float timer = 1.5f;
    private bool count = false;
    private GameObject findPlayer;
    private GameObject[] findKey;
    private LevelManager levelManager;
    private KeyManager keyManager;
    private GameObject[] test;

    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();
        keyManager = FindObjectOfType<KeyManager>();
        findPlayer = GameObject.Find("CharacterRobotBoy");
        test = GameObject.FindGameObjectsWithTag("PickUp");
    }

    private void Update() {
        UnityStandardAssets._2D.PlatformerCharacter2D player = findPlayer.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
        gameObject.GetComponent<Collider2D>().enabled = true;
        if(count == true) {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                timer = 1.5f;
                //SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
                levelManager.Respawn();
                if(test.Length >0) {
                    keyManager.RenewKey();
                }
                count = false;

                if(player.M_IsAlive) {
                    player.DeathsNumber--;
                }
            }
        }
        if(player.DeathsNumber == 1) {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
            
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            gameObject.GetComponent<Collider2D>().enabled = false;
            UnityStandardAssets._2D.PlatformerCharacter2D player = findPlayer.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();

            if(player.DeathsNumber == 0) {
                count = true;
                player.M_IsAlive = false;
                player.M_Anim.SetBool("isDead", true);
            }
        }
    }
}