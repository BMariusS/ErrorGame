using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D {
    public class BossRestarter : MonoBehaviour {
        //    private float timer = 1.5f;
        //    private bool count = false;

        //    private void Update()
        //    {
        //        if (count == true)
        //        {
        //            timer -= Time.deltaTime;
        //            if (timer <= 0)
        //            {
        //                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        //            }
        //        }
        //    }
        //    void OnCollisionEnter2D(Collision2D other)
        //    {
        //        if (other.gameObject.tag == "Player")
        //        {
        //            count = true;
        //        }
        //    }
        //}




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

            PlatformerCharacter2D player = findPlayer.gameObject.GetComponent<PlatformerCharacter2D>();
            //gameObject.GetComponent<Collider2D>().enabled = true;
            if(levelManager.IsRespawned) {
                gameObject.transform.position = new Vector2(-9.5f, 9.13f);
                levelManager.IsRespawned = false;
            }
            if(count == true) {
                timer -= Time.deltaTime;
                if(timer <= 0) {
                    timer = 1.5f;

                    levelManager.Respawn();
                    if(levelManager.IsRespawned) {
                        gameObject.transform.position = new Vector2(-9.5f, 9.13f);
                        levelManager.IsRespawned = false;
                    }
                    if(test.Length > 0) {
                        keyManager.RenewKey();
                    }
                    count = false;

                    if(player.M_IsAlive) {
                        player.DeathsNumber--;
                    }
                }
            }
            //if(player.DeathsNumber == 1) {
                // gameObject.GetComponent<Collider2D>().enabled = false;
            //}

        }
        void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.tag == "Player") {
                //gameObject.GetComponent<Collider2D>().enabled = false;
                PlatformerCharacter2D player = findPlayer.gameObject.GetComponent<PlatformerCharacter2D>();
                //Debug.Log(player.DeathsNumber);
                if(player.DeathsNumber == 0) {  
               // Debug.Log("coliziune");
                    count = true;
                    player.M_IsAlive = false;
                    player.M_Anim.SetBool("isDead", true);
                }
            }
        }
    }
}