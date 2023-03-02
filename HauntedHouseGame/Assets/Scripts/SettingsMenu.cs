using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu: MonoBehaviour {
    public AudioSource ambientSounds;
    public GraphicRaycaster canvasMenuRaycaster;
    public SettingsAndPrefs settingsAndPrefs;
    public GameObject settingsButton, canvasScore;
    public CanvasGroup settingsCanvasGroup;
    bool execute = false, activeState = false;
    public bool activateCanvas = false, interactable = true;

    void Awake () {
        settingsCanvasGroup = GetComponent<CanvasGroup> ();
        LeanTween.alphaCanvas (settingsCanvasGroup, 0f, 0f);
        canvasMenuRaycaster = GetComponent<GraphicRaycaster> ();
        settingsButton = GameObject.Find ("SettingsButton");
        if (!AmIOnInitialMenu ()) {
            ambientSounds = GameObject.Find ("Ambient").GetComponent<AudioSource> ();
            canvasScore = GameObject.Find ("CanvasScore");
        }
    }

    void Update () {
        if (canvasMenuRaycaster.IsActive () || settingsButton.activeSelf == true) {
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
                canvasMenuRaycaster.enabled = activeState;
                if (!AmIOnInitialMenu ()) {
                    canvasScore.SetActive (!activeState);
                }
                LeanTween.alphaCanvas (settingsCanvasGroup, 1f, 1f).setEaseOutCubic ().setOnComplete (() => {
                    if (!AmIOnInitialMenu ()) {
                        if (ambientSounds.isPlaying) {
                            ambientSounds.Pause ();
                            Time.timeScale = 0;
                        }
                    }
                    interactable = true;
                });

            } else if (!activateCanvas) {
                if (!AmIOnInitialMenu ()) {
                    Time.timeScale = 1;
                    canvasScore.SetActive (!activeState);
                }
                canvasMenuRaycaster.enabled = activeState;
                LeanTween.alphaCanvas (settingsCanvasGroup, 0f, 1f).setEaseOutCubic ().setOnComplete (() => {
                    if (!AmIOnInitialMenu ()) {
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

        if (SceneManager.GetActiveScene ().name == "InitialScene") {
            x = true;
        } else {
            x = false;
        }
        return x;
    }
}
