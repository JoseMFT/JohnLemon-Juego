using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer: MonoBehaviour {
    public float catchTime = 2f;
    public Transform playerTransform;
    public GameEnding gameEnding;
    public bool playerInRange = false, exclamationPlaying = false;
    public GameObject exclamation, canvasMenu, joystick;
    Vector3 direction;
    public AudioSource otherSounds, exclamationSFX;
    bool prevCanvasState = false, currentCanvasState = false;
    void Start () {
        canvasMenu = GameObject.Find ("MenuCanvas");
        joystick = GameObject.Find ("JoyStick");
    }

    // Update is called once per frame
    void Update () {
        /*if (joystick.activeSelf == canvasMenu.activeSelf) {
            joystick.SetActive (!canvasMenu.activeSelf);
        }*/
        if (exclamationSFX.isPlaying) {
            exclamationPlaying = true;
        } else {
            exclamationPlaying = false;
        }
        if (playerInRange == true) {
            catchTime -= Time.deltaTime;
            direction = playerTransform.position - transform.position + Vector3.up;

            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast (ray, out raycastHit) == true) {
                if (raycastHit.collider.transform == playerTransform) {
                    if (catchTime <= 0f) {
                        gameEnding.CaughtPlayer ();
                    }
                }
            }
        }

        if (otherSounds != null) {
            if (canvasMenu != null) {
                currentCanvasState = canvasMenu.activeSelf;
                if (prevCanvasState != currentCanvasState) {
                    if (canvasMenu.activeSelf) {
                        otherSounds.Pause ();
                    } else if (!canvasMenu.activeSelf) {
                        otherSounds.Play ();
                    }
                }
                prevCanvasState = currentCanvasState;
            }
        }
    }

    private void OnTriggerEnter (Collider other) {
        if (other.transform == playerTransform) {
            catchTime = 2f;
            exclamation.SetActive (true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.transform == playerTransform) {
            catchTime = 2f;
            playerInRange = false;
            exclamation.SetActive (false);
        }
    }

}
