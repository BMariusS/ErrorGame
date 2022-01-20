using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOptions : MonoBehaviour {

    private string musicOn;
    private bool on = true;
    private GameObject findMusic;
    private AudioSource musicSource;
    private AudioSource spikeSource;
    private AudioSource spikeBallSource;
    private AudioSource killZoneSource;
    private AudioSource gameManagerSource;
    private AudioSource[] doorSource;

    private string sfxOn;
    private bool sfx = true;
    private GameObject findPlayer;
    private AudioSource[] sfxSource;
    private GameObject[] spikes;
    private GameObject[] spikeBalls;
    private GameObject[] killZones;
    private GameObject gameManager;
    private GameObject[] doors;

    private void Start() {

        findMusic = GameObject.Find("Audio Source");
        musicSource = findMusic.GetComponent<AudioSource>();

        if(PlayerPrefs.GetString("MusicOn") == "true") {
            on = true;
            musicSource.mute = false;
        }

        else if(PlayerPrefs.GetString("MusicOn") == "false") {
            on = false;
            musicSource.mute = true;
        }

        if(on) {
            musicSource.mute = false;
        }

        //if (PlayerPrefs.GetString("SFXOn") == "true") {
        //    sfx = true;
        //}

        //else if (PlayerPrefs.GetString("SFXOn") == "false") {
        //    sfx = false;
        //}
    }

    private void Update() {


        
        if(GameObject.Find("CharacterRobotBoy")) {
            findPlayer = GameObject.Find("CharacterRobotBoy");
            sfxSource = findPlayer.GetComponents<AudioSource>();

            if(PlayerPrefs.GetString("SFXOn") == "true") {
                sfx = true;
                for(int i = 0; i < sfxSource.Length; i++) {
                    sfxSource[i].mute = false;
                }

                if (GameObject.FindGameObjectWithTag("Spikes"))
                {
                    spikes = GameObject.FindGameObjectsWithTag("Spikes");
                    foreach (GameObject spike in spikes)
                    {
                        spikeSource = spike.GetComponent<AudioSource>();
                        spikeSource.mute = false;
                    }
                }

                if (GameObject.FindGameObjectWithTag("SpikeBall"))
                {
                    spikeBalls = GameObject.FindGameObjectsWithTag("SpikeBall");
                    foreach (GameObject spikeBall in spikeBalls)
                    {
                        foreach (Transform child in spikeBall.transform)
                        {
                            if (child.CompareTag("SpikeBall"))
                            {
                            spikeBallSource = child.GetComponent<AudioSource>();
                            spikeBallSource.mute = false;
                            }
                        }
                    }
                }

                if (GameObject.FindGameObjectWithTag("Killzone"))
                {
                    killZones = GameObject.FindGameObjectsWithTag("Killzone");
                    foreach (GameObject killZone in killZones)
                    {
                        killZoneSource = killZone.GetComponent<AudioSource>();
                        killZoneSource.mute = false;
                    }
                }

                if (GameObject.FindGameObjectWithTag("NextLevel"))
                {
                    gameManager = GameObject.FindGameObjectWithTag("NextLevel");
                    gameManagerSource = gameManager.GetComponent<AudioSource>();
                    gameManagerSource.mute = false;
                }

                if (GameObject.FindGameObjectWithTag("Door"))
                {
                    doors = GameObject.FindGameObjectsWithTag("Door");
                    foreach (GameObject door in doors)
                    {
                        doorSource = door.GetComponents<AudioSource>();
                        for(int i = 0; i<doorSource.Length; i++)
                        {
                            doorSource[i].mute = false;
                        }
                    }
                }
            }

            else if(PlayerPrefs.GetString("SFXOn") == "false") {
                sfx = false;
                for(int i = 0; i < sfxSource.Length; i++) {
                    sfxSource[i].mute = true;
                }

                if (GameObject.FindGameObjectWithTag("Spikes"))
                {
                    spikes = GameObject.FindGameObjectsWithTag("Spikes");
                    foreach (GameObject spike in spikes)
                    {
                        spikeSource = spike.GetComponent<AudioSource>();
                        spikeSource.mute = true;
                    }
                }

                if (GameObject.FindGameObjectWithTag("SpikeBall"))
                {
                    spikeBalls = GameObject.FindGameObjectsWithTag("SpikeBall");
                    foreach (GameObject spikeBall in spikeBalls)
                    {
                        foreach (Transform child in spikeBall.transform)
                        {
                            if (child.CompareTag("SpikeBall"))
                            {
                                spikeBallSource = child.GetComponent<AudioSource>();
                                spikeBallSource.mute = true;
                            }
                        }

                    }
                }

                if (GameObject.FindGameObjectWithTag("Killzone"))
                {
                    killZones = GameObject.FindGameObjectsWithTag("Killzone");
                    foreach (GameObject killZone in killZones)
                    {
                        killZoneSource = killZone.GetComponent<AudioSource>();
                        killZoneSource.mute = true;
                    }
                }

                if (GameObject.FindGameObjectWithTag("NextLevel"))
                {
                    gameManager = GameObject.FindGameObjectWithTag("NextLevel");
                    gameManagerSource = gameManager.GetComponent<AudioSource>();
                    gameManagerSource.mute = true;
                }

                if (GameObject.FindGameObjectWithTag("Door"))
                {
                    doors = GameObject.FindGameObjectsWithTag("Door");
                    foreach (GameObject door in doors)
                    {
                        doorSource = door.GetComponents<AudioSource>();
                        for (int i = 0; i < doorSource.Length; i++)
                        {
                            doorSource[i].mute = true;
                        }
                    }
                }
            }

            if (sfx)
            {
                for (int i = 0; i < sfxSource.Length; i++)
                {
                    sfxSource[i].mute = false;
                }
            }
        }
    }

    public void muteMusic() {
        on = !on;

        if(on) {
            musicOn = "true";
            musicSource.mute = false;
        }
        else {
            musicOn = "false";
            musicSource.mute = true;
        }

        PlayerPrefs.SetString("MusicOn", musicOn);
    }

    public void muteSfxMenu() {
        sfx = !sfx;

        if(sfx) {
            sfxOn = "true";           
        }
        else {
            sfxOn = "false";
            
        }

        PlayerPrefs.SetString("SFXOn", sfxOn);
        Debug.Log(sfx);
        Debug.Log("sfxOn" + sfxOn);
    }
}
