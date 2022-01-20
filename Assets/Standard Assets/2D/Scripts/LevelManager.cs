using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlatformerCharacter2D player;
    //private AudioPlayCollision verifyTouch;
    private bool isRespawned = false;

    // Use this for initialization
    void Start() {
        player = FindObjectOfType<PlatformerCharacter2D>();
        //verifyTouch = FindObjectOfType<AudioPlayCollision>();
    }

    public void Respawn() {
        Debug.Log("Player Respawn");
        isRespawned = true;
        //Debug.Log(player.Touch);
        player.Touch = false;
        player.transform.position = currentCheckpoint.transform.position;
        player.M_IsAlive = true;
        player.M_Anim.SetBool("isDead", false);
        if(player.M_Rigidbody2D.gravityScale < 0)
        {
            player.M_Rigidbody2D.gravityScale *= -1;
        }
    }

    public bool IsRespawned {
        get {
            return isRespawned;
        }

        set {
            isRespawned = value;
        }
    }
}
