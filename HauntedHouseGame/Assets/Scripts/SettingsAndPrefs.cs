using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsAndPrefs: MonoBehaviour {
    public static SettingsAndPrefs Instance;
    public GameObject settingsCanvas;
    public Slider volumeController;
    public int coins;
    float gameVolume, prevGameVolume;
    string prevScene, currentScene;

    void Awake () {
        if (Instance != null) {
            Destroy (gameObject);
        }
        Instance = this;
        DontDestroyOnLoad (gameObject);
        DontDestroyOnLoad (settingsCanvas);
        DontDestroyOnLoad (volumeController);
    }
    void Start () {
        LoadPrefs ();
    }

    void FixedUpdate () {

        if (settingsCanvas != null) {
            gameVolume = volumeController.value;
            AudioListener.volume = volumeController.value;
        }

        if (gameVolume != prevGameVolume) {
            SavePrefs ();
        }
        prevGameVolume = gameVolume;
    }


    public void SavePrefs () {
        PlayerPrefs.SetFloat ("gameVolume", 1f);
        PlayerPrefs.SetInt ("coins", 0);
        PlayerPrefs.Save ();
    }

    public bool AmIOnInitialMenu () {
        bool x;

        if (SceneManager.GetActiveScene ().name == "InitialScene") {
            x = true;
        } else {
            x = false;
        }
        return x;
    }

    public void LoadPrefs () {
        PlayerPrefs.GetFloat ("gameVolume", 1f);
        AudioListener.volume = gameVolume;
        volumeController.value = gameVolume;
        prevGameVolume = gameVolume;
    }
}