using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding: MonoBehaviour {
    public float fadeDuration = 1f, displayImageDuration = 1f;
    public GameObject player, settingsButton, joyStick;
    bool playerHitExit = false, playerCaught = false, audioHasPlayed = false;
    float timer = 0f;
    public CanvasGroup exitCanvas, caughtCanvas;
    public AudioSource exitAudio, caughtAudio;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (playerHitExit == true) {
            EndLevel (exitCanvas, false, exitAudio);
        } else if (playerCaught == true) {
            EndLevel (caughtCanvas, true, caughtAudio);
        }
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject == player) {
            playerHitExit = true;
        }
    }

    public void CaughtPlayer () {
        playerCaught = true;
    }

    public void EndLevel (CanvasGroup imageCanvasGroup, bool restartGame, AudioSource audioSource) {
        settingsButton.SetActive (false);
        joyStick.SetActive (false);
        if (audioHasPlayed != true) {
            audioSource.Play ();
            audioHasPlayed = true;
        }
        timer += Time.deltaTime;
        imageCanvasGroup.alpha = timer / fadeDuration;
        if (timer > fadeDuration + displayImageDuration) {
            if (restartGame == true) {
                SceneManager.LoadScene (1);
            } else {
                Application.Quit ();
            }
        }
    }
}
