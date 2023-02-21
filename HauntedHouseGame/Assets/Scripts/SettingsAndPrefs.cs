using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SettingsAndPrefs : MonoBehaviour
{
    public GameObject settingsCanvas;
    public Slider volumeController;
    public TextMeshProUGUI volumeValueText;
    public int coins;
    float gameVolume, prevGameVolume;

    void Start () {
        PlayerPrefs.GetFloat ("gameVolume", AudioListener.volume);
        AudioListener.volume = gameVolume;
        prevGameVolume = gameVolume;
    }

    void FixedUpdate () {
        gameVolume = AudioListener.volume;

        if (gameVolume != prevGameVolume) {
            SavePrefs ();
        }
        prevGameVolume = gameVolume;

        if (settingsCanvas != null) {  
            AudioListener.volume = volumeController.value;           
        }
    }


    public void SavePrefs()
    {
        PlayerPrefs.SetFloat ("gameVolume", 0f);
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.Save();
    }
}