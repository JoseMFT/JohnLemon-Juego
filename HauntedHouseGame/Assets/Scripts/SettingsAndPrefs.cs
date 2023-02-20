using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsAndPrefs : MonoBehaviour
{
    public int coins;
    // Start is called before the first frame update
    void Start()
    {
        SavePrefs();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SavePrefs()
    {
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.Save();
    }
}