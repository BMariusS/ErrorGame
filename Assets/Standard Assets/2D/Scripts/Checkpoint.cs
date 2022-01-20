using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    // Use this for initialization
    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject findPlayer = GameObject.Find("CharacterRobotBoy");
            CollectObject key = findPlayer.GetComponent<CollectObject>();
            UnityStandardAssets._2D.PlatformerCharacter2D player = findPlayer.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
            if (key.IsCollected && player.M_IsAlive)
            {
                levelManager = FindObjectOfType<LevelManager>();
                levelManager.currentCheckpoint = gameObject;
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
