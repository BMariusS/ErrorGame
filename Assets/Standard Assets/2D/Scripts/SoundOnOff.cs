using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour {

    [SerializeField]
    private Sprite spriteOn;
    [SerializeField]
    private Sprite spriteOff;
    private Image imageChanged;
    // Use this for initialization
    void Start () {
       imageChanged  = GameObject.Find("Sounds").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if(PlayerPrefs.GetString("MusicOn") == "true") {
            imageChanged.sprite = spriteOn;
        }
        else if(PlayerPrefs.GetString("MusicOn") == "false") {
            imageChanged.sprite = spriteOff;
        }
	}
}
