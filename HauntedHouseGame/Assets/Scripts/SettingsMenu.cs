using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioSource ambientSounds;
    public SettingsAndPrefs settingsAndPrefs;
    public GameObject settingsCanvasGameObject, settingsButton;
    public CanvasGroup settingsCanvasGroup;
    bool execute = false, activeState = false;
    public bool activateCanvas = false, interactable = true;

    void Awake () {
        LeanTween.alphaCanvas (settingsCanvasGroup, 0f, 0f);
    }
    void Update()
    {
        if (settingsCanvasGameObject.activeSelf == true || settingsButton.activeSelf == true) {
            if (Input.GetKeyUp ("escape")) {
                SettingsActivation ();
            }
        }
    }

    public void SettingsActivation () {
        if (interactable == true) {
            interactable = false;
            activateCanvas = !activateCanvas;
            activeState = !activeState;

            if (activateCanvas) {
                settingsCanvasGameObject.SetActive (activeState);
                LeanTween.alphaCanvas (settingsCanvasGroup, 1f, 1f).setEaseOutCubic ().setOnComplete (() => {
                    Time.timeScale = 0;
                    if (!AmIOnInitialMenu ()) {
                        if (ambientSounds.isPlaying) {
                            ambientSounds.Pause ();
                        }
                    }
                    interactable = true;
                });

            } else if (!activateCanvas) {
                Time.timeScale = 1;
                LeanTween.alphaCanvas (settingsCanvasGroup, 0f, 1f).setEaseOutCubic ().setOnComplete (() => {
                    settingsCanvasGameObject.SetActive (activeState);
                    if (!AmIOnInitialMenu()) {
                        if (!ambientSounds.isPlaying) {
                            ambientSounds.Play ();
                        }
                    }
                    interactable = true;
                });
            }
        }
    }

    public bool AmIOnInitialMenu () {
        bool x;

        if (SceneManager.GetActiveScene().name == "InitialScene") {
            x = true;
        } else {
            x = false;
        }
        return x;
    }
}
