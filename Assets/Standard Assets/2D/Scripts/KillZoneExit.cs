using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KillZoneExit : MonoBehaviour {

    private float timer = 1f;
    private bool count = false;
    private GameObject findPlayer;
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
        if(count == true) {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                timer = 1f;
                //Debug.Log("Respawned");
                levelManager.Respawn();
                if (test.Length > 0)
                {
                    keyManager.RenewKey();
                }
                count = false;
                if(player.M_IsAlive) {
                    player.DeathsNumber--;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            UnityStandardAssets._2D.PlatformerCharacter2D player = findPlayer.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
            if(player.DeathsNumber == 0) {
                count = true;
                player.M_IsAlive = false;
                player.M_Anim.SetBool("isDead", true);
            }
        }
        //if(other.gameObject.tag == "Boss")
        //{
        //    GetComponent<Collider2D>().enabled = false;
        //}
    }
}
