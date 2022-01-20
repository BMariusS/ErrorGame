using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class KeyManager : MonoBehaviour {

    public GameObject currentKey;
    private PlatformerCharacter2D player;
    private CollectObject findCollection;

    // Use this for initialization
    void Start() {
        player = FindObjectOfType<PlatformerCharacter2D>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void RenewKey() {
        GameObject findPlayer = GameObject.Find("CharacterRobotBoy");
        CollectObject key = findPlayer.GetComponent<CollectObject>();
        if(key.IsCollected) {
            Instantiate(currentKey, currentKey.transform.position, currentKey.transform.rotation);
            Debug.Log(Instantiate(currentKey, currentKey.transform.position, currentKey.transform.rotation));
            currentKey.SetActive(true);
            Debug.Log("Key found and appeared!");
            key.IsCollected = false;
        }
    }
}
