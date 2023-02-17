using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer: MonoBehaviour {
    public Transform playerTransform;
    public GameEnding gameEnding;
    bool playerInRange = false;
    Vector3 direction;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (playerInRange == true) {
            direction = playerTransform.position - transform.position + Vector3.up;

            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast (ray, out raycastHit) == true) {
                if (raycastHit.collider.transform == playerTransform) {
                    gameEnding.CaughtPlayer ();
                }
            }
        }
    }

    private void OnTriggerEnter (Collider other) {
        if (other.transform == playerTransform) {
            playerInRange = true;
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.transform == playerTransform) {
            playerInRange = false;
        }
    }
}
