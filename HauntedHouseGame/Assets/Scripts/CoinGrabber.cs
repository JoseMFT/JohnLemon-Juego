using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinGrabber : MonoBehaviour
{
    int counterText;
    public GameObject prefabCoinExplosion;
    public SettingsAndPrefs settingsAndPrefs;
    public TextMeshProUGUI coinCounter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counterText = settingsAndPrefs.coins;
        coinCounter.text = counterText.ToString() + "x";
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Token")
        {
            settingsAndPrefs.coins++;
            settingsAndPrefs.SavePrefs();
            Instantiate (prefabCoinExplosion, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
