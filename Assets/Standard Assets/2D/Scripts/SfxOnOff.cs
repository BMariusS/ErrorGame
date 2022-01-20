using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxOnOff : MonoBehaviour {

    private Image imageChanged;
    private Image sfxChanged;

    [SerializeField]
    private Sprite sfxOn;
    [SerializeField]
    private Sprite sfxOff;
    // Use this for initialization
    void Start() {
        sfxChanged = GameObject.Find("SFX").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update() {
        if(PlayerPrefs.GetString("SFXOn") == "true") {
            sfxChanged.sprite = sfxOn;
        }
        else if(PlayerPrefs.GetString("SFXOn") == "false") {
            sfxChanged.sprite = sfxOff;
        }
    }
}
