using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScaler: MonoBehaviour {
    Vector3 ogSize;
    public GameObject settingsCanvasGameObject;
    public CanvasGroup settingsCanvasGroup;
    bool activeState = false, execute = false;
    float faderValue = -1f, timer = 0f;

    void Start () {
        ogSize = transform.localScale;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp ("escape")) {
            SettingsActivation ();
        }

        if (execute == true) {
            if (timer < 1f) {
                timer += Time.deltaTime;
                settingsCanvasGroup.alpha = timer / faderValue * Time.deltaTime;
            } else {
                timer = 0f;
                execute = false;
            }
        }
    }

    public void ScaleUp () {
        LeanTween.scale (gameObject, ogSize * 1.1f, .1f).setEaseOutCubic ();
    }

    public void ScaleDown  () {
        LeanTween.scale (gameObject, ogSize, .1f).setEaseInCubic ();
    }

    public void SettingsActivation () {
            faderValue = -1 * faderValue;
            Time.timeScale = 1 - Time.timeScale / 1;
            activeState = !activeState;
            settingsCanvasGameObject.SetActive (activeState);
            execute = true;
    }

    public void QuitGame () {
        Application.Quit ();
    }
}
