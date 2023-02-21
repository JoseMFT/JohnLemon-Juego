using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinGrabber : MonoBehaviour
{
    int counterText;
    public AudioSource coinAudio;
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
            coinAudio = other.gameObject.GetComponent<AudioSource> ();
            if (!coinAudio.isPlaying) {
                coinAudio.Play ();
            }
            settingsAndPrefs.coins++;
            settingsAndPrefs.SavePrefs();
            Instantiate (prefabCoinExplosion, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject, .5f);
        }
    }
}
