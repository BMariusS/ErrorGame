using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class NextLevel : MonoBehaviour
    {
        private GameObject findPlayer;
        private PlatformerCharacter2D player;

        private float timer = 1.5f;
        private bool count = false;

        private void Update()
        {
            if (count == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0 && player.M_IsAlive)
                {
                    SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex + 1);
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            findPlayer = GameObject.Find("CharacterRobotBoy");
            player = findPlayer.gameObject.GetComponent<PlatformerCharacter2D>();
            if (other.tag == "Player" && player.M_IsAlive)
            {
                count = true;
            }
        }
    }
}

