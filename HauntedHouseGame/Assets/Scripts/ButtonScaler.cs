using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScaler: MonoBehaviour {
    Vector3 ogSize;

    void Start () {
        ogSize = transform.localScale;
    }

    public void ScaleUp () {
        LeanTween.scale (gameObject, ogSize * 1.1f, .15f).setEaseOutCubic ();
    }

    public void ScaleDown  () {
        LeanTween.scale (gameObject, ogSize, .15f).setEaseInCubic ();
    }

    public void QuitGame () {
        Application.Quit ();
    }

    public void EnterGame () {
        SceneManager.LoadScene (1);
    }
}
