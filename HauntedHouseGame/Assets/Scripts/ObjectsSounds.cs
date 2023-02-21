using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSounds : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject canvasMenu;
    bool prevCanvasState = false, currentCanvasState = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasMenu!= null) {
            currentCanvasState = canvasMenu.activeSelf;
            if (prevCanvasState != currentCanvasState) {
                if (canvasMenu.activeSelf) {
                    audioSource.Pause ();
                } else if (!canvasMenu.activeSelf) {
                    audioSource.Play ();
                }
            }
            prevCanvasState= currentCanvasState;   
        }
    }
}
